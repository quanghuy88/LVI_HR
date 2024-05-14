using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Abstraction.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authorization
{
    public static class PermissionAuthorizationExtensions
    {

        //public static bool IsAdministrator(this HttpContext context) => context.RequestServices.GetRequiredService<IContextUserService>().IsAdministrator;
        public static IServiceCollection AddPermissionPolicyAuthorization(this IServiceCollection services)
        {
            //services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();
            services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
            return services;
        }
        public static bool IsAdministrator(this HttpContext context) => context.RequestServices.GetRequiredService<IContextUserService>().IsAdministrator;

        public static AuthenticationBuilder AddPermissionPolicyCookieAuthentication(this IServiceCollection services)
        {
            return services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public static AuthenticationBuilder ConfigurePermissionPolicyCookieAuthentication(this AuthenticationBuilder builder, IConfiguration config)
        {
            return builder.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.Cookie.Name = config["CookieAuthentication:Name"] ?? $"{AppDomain.CurrentDomain.FriendlyName}.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}";
                options.LoginPath = config["CookieAuthentication:LoginPath"] ?? "/Account/Login";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(config.GetValue<double?>("CookieAuthentication:ExpireTimeSpan") ?? 60);
                options.SlidingExpiration = config.GetValue<bool?>("CookieAuthentication:SlidingExpiration") ?? false;
                options.Events.OnRedirectToAccessDenied = async context =>
                {
                    var httpContextService = context.HttpContext.RequestServices.GetRequiredService<IHttpContextService>();
                    await httpContextService.WriteViewResponseAsync("~/Views/Shared/AccessDenied.cshtml", 403);
                };
                options.Events.OnRedirectToLogin += async context =>
                {
                    var httpContextService = context.HttpContext.RequestServices.GetRequiredService<IHttpContextService>();
                    if (!httpContextService.IsAjaxRequest) return;
                    await httpContextService.WriteEmptyResponseAsync(401);
                };
            });
        }
    }
}
