using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Application.Services
{
    public static class ServiceImplementationExtensions
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services) => services.InjectServices();
    }
}
