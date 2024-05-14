using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Authorization
{
    public class PermissionAuthorizationRequirement : IAuthorizationRequirement
    {
        public string RequiredResource { get; private set; }
    }
}
