using Core.Enums;
using Injection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Services.Abstraction.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ContextUserService : IContextUserService, IScopedInjection
    {
        protected readonly HttpContext _httpContext;
        protected readonly JsonSerializerOptions _jsonOptions;
        protected readonly IConfiguration _config;

        public ContextUserService(IServiceProvider serviceProvider)
        {
            _httpContext = serviceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext;
            _jsonOptions = serviceProvider.GetRequiredService<IOptions<JsonSerializerOptions>>()?.Value;
            _config = serviceProvider.GetRequiredService<IConfiguration>();
        }

        public bool IsAuthenticated => _httpContext.User.Identity.IsAuthenticated;

        public decimal UserId => Convert.ToDecimal(_httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid)?.Value ?? "0");

        public string UserName => _httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? "";

        public string UserDisplayName => _httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value ?? "";

        public decimal BranchId => Convert.ToDecimal(_httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.PrimaryGroupSid)?.Value ?? "0");

        public decimal DeparmentId => Convert.ToDecimal(_httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.GroupSid)?.Value ?? "0");

        public string[] Roles
        {
            get => _httpContext.User.Claims
                .Where(x => x.Type == ClaimTypes.Role && !string.IsNullOrEmpty(x.Value))
                .SelectMany(x => JsonSerializer.Deserialize<string[]>(x.Value))
                .ToArray();
        }

        public string AccessibleResources
        {
            get
            {
                var resources = _httpContext.User.Claims
                    .Where(x => x.Type == ClaimTypes.Actor && !string.IsNullOrEmpty(x.Value))
                    .SelectMany(x => JsonSerializer.Deserialize<Dictionary<string, object>>(x.Value))
                    .Select(x => x.Key)
                    .Distinct();
                return JsonSerializer.Serialize(resources, new JsonSerializerOptions() { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
            }
        }

        public bool IsAdministrator => Roles.Any(x => x.ToLower() == _config["AdminRoleCode"]?.ToLower());
    }
}
