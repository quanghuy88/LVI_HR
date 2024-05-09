using Application.Authentication;
using Constract.Authentication;
using Core.Dtos.Authorization;
using Core.Dtos.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Services.Abstraction.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class Authentication : IAuthenticationService
    {
        private readonly HttpContext _httpContext;
        //private readonly IAuthentication _authenticationService;
        private readonly JwtSetting _jwtSettings;
        public Authentication(IServiceProvider serviceProvider,
                              JwtSetting jwtSetting)
        {
            _httpContext = serviceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext;
            _jwtSettings = jwtSetting;
        }
        public Task<ResultLogin> Login(LoginRequest request)
        {
            var resultLogin = new ResultLogin();
            var token = JwtHelpers.GenTokenkey(new Core.Dtos.Jwt.JwtUserTokens()
            {
                GuidId = Guid.NewGuid(),
                UserName = request.UserName,
                Id = '1',
                Name = request.UserName,
                DepartmentID = '1',
                DepartmentName = "cntt",
                BranchId = '2',
                BranchCode = "ho",
                BranchName = "ho",
                Role = null,
                AccountMonthId = 1,
                AccountMonthCode = "",
                LstPermission = null,
            }, _jwtSettings);
            resultLogin.Token = JsonConvert.SerializeObject(token);
            return null;
        }
    }
}
