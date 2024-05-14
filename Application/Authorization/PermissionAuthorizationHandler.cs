using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Services.Abstraction.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authorization
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionAuthorizationRequirement>
    {
        private readonly IHttpContextAccessor _httpAccessor;

        public PermissionAuthorizationHandler(IHttpContextAccessor httpAccessor)
        {
            _httpAccessor = httpAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionAuthorizationRequirement requirement)
        {
            return Task.CompletedTask;
        }
    }
}
