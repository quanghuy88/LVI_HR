using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddExternalDbContexts(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<LVIDashboardContext>(options => options.UseSqlServer(config.GetConnectionString("LVI.DW")));
            //services.AddDbContext<BICContractLoggingContext>(options => options.UseSqlServer(config.GetConnectionString("BIC.Contract")));
            //services.AddDbContext<BICSystemContext>(options => options.UseSqlServer(config.GetConnectionString("BIC.System")));
            //services.AddDbContext<BICSystemLoginContext>(options => options.UseSqlServer(config.GetConnectionString("BIC.System")));
            return services;
        }
    }
}
