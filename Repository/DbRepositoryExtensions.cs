using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Repository
{
    public static class DbRepositoryExtensions
    {
        public static IServiceCollection AddExternalDbRepositories(this IServiceCollection services) => services.InjectServices();
    }
}
