using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utitlity
{
    public static class ServiceProviderHelper
    {
        private static readonly Dictionary<Type, Func<Type, Type, object>> _injectionRules = new Dictionary<Type, Func<Type, Type, object>>()
        {
            { typeof(ISingletonInjection), null },
            { typeof(IScopedInjection), null },
            { typeof(ITransientInjection), null }
        };

        public static T GetService<T>(this IServiceProvider serviceProvider, T service) where T : class => serviceProvider.GetService<T>();

        public static T GetService<T>(this IServiceProvider serviceProvider) where T : class => serviceProvider.GetService(typeof(T)) as T;


        public static T RegisterServiceInjection<T>(this T services, Func<Type, Type, T> addSingleton, Func<Type, Type, T> addScoped, Func<Type, Type, T> addTransient)
        {
            _injectionRules[typeof(ISingletonInjection)] = (interfaceType, classType) => addSingleton(interfaceType, classType);
            _injectionRules[typeof(IScopedInjection)] = (interfaceType, classType) => addScoped(interfaceType, classType);
            _injectionRules[typeof(ITransientInjection)] = (interfaceType, classType) => addTransient(interfaceType, classType);
            return services;
        }

        public static T InjectServices<T>(this T services)
        {
            var injectableClassServices = Assembly.GetCallingAssembly().GetExportedTypes()
                .Where(x => x.IsClass && x.IsPublic && typeof(IInjection).IsAssignableFrom(x) && !x.IsAbstract)
                .GroupBy(x => x.FullName)
                .Select(x => x.FirstOrDefault());
            foreach (var classService in injectableClassServices)
            {
                var injectionFunc = _injectionRules.FirstOrDefault(x => x.Key.IsAssignableFrom(classService)).Value;
                if (injectionFunc == null) continue;
                var injectableInterfaceServices = classService.GetInterfaces()
                    .Where(x =>
                        classService.IsGenericType == x.IsGenericType &&
                        !_injectionRules.Any(r => r.Key == x) &&
                        typeof(IInjection).IsAssignableFrom(x) &&
                        typeof(IInjection) != x
                    );
                foreach (var interfaceService in injectableInterfaceServices)
                {
                    if (classService.IsGenericType) injectionFunc(interfaceService.GetGenericTypeDefinition(), classService.GetGenericTypeDefinition());
                    else injectionFunc(interfaceService, classService);
                }
            }
            return services;
        }
    }
}
