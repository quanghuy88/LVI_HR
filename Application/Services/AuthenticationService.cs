using Application.Authentication;
using Constract.Authentication;
using Constract.Model;
using Core.Dtos.Authorization;
using Core.Dtos.Jwt;
using Core.Entities;
using Injection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Repository.Base.LVIDashboard;
using Services.Abstraction.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;


namespace Application.Services
{
    public class AuthenticationService: IAuthenticationService, IScopedInjection
    {
        private readonly HttpContext _httpContext;
        //private readonly IAuthentication _authenticationService;
        private readonly JwtSetting _jwtSettings;
        private readonly ILVIDashboardRepository<dwh_admin_user> _userRepo;
        private readonly ILVIDashboardRepository<dwh_list_branch> _branchRepo;
        public AuthenticationService(IServiceProvider serviceProvider, JwtSetting jwtSetting)
        {
            _httpContext = serviceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext;
            _jwtSettings = jwtSetting;
            _userRepo = serviceProvider.GetService(_userRepo);
            _branchRepo = serviceProvider.GetService(_branchRepo);
        }
        public async Task<ResultLogin> LoginAsync(LoginRequest request)
        {
            try
            {
                var vuser = await _userRepo.AsActiveNoTracking()
                            .FirstOrDefaultAsync(x => x.username == request.Username && x.password == Md5Helper.GetMD5Hash(request.Password));

                if (vuser != null)
                {
                    var vbranch = await _branchRepo.AsActiveNoTracking().FirstOrDefaultAsync(x => x.id == vuser.branch_id);
                    var vunit = await _branchRepo.AsActiveNoTracking().FirstOrDefaultAsync(x => x.id == vuser.unit_id);
                    var resultLogin = new ResultLogin();
                    var token = JwtHelpers.GenTokenkey(new Core.Dtos.Jwt.JwtUserTokens()
                    {
                        GuidId = Guid.NewGuid(),
                        UserName = request.Username,
                        Id = vuser.id,
                        Name = vuser.name
                        //DepartmentID = vunit != null ? vunit.id : null,
                        //DepartmentName = vunit != null ? vunit.name : "",
                        //BranchId = vbranch != null ? vbranch.id : null,
                        //BranchCode = vbranch != null ? vbranch.code : "",
                        //BranchName = vbranch != null ? vbranch.name : "",
                        //Role = null,
                        //LstPermission = null,
                        //Id = '1',
                        //Name = request.Username,
                        //DepartmentID = '1',
                        //DepartmentName = "cntt",
                        //BranchId = '2',
                        //BranchCode = "ho",
                        //BranchName = "ho",
                        //Role = null,
                        //AccountMonthId = 1,
                        //AccountMonthCode = "",
                        //LstPermission = null,
                    }, _jwtSettings);
                    resultLogin.id = vuser.id;
                    resultLogin.username = request.Username;
                    resultLogin.password = request.Password;
                    resultLogin.name = vuser.name;
                    resultLogin.departmentId = vunit != null ? vunit.id : null;
                    resultLogin.departmentName = vunit != null ? vunit.name : null;
                    resultLogin.branch_id = vbranch != null ? vbranch.id : null;
                    resultLogin.branch_code = vbranch != null ? vbranch.code : "";
                    resultLogin.branch_name = vbranch != null ? vbranch.name : "";
                    resultLogin.Token = token;
                    resultLogin.msg = "Login succcess!";
                    return resultLogin;
                }
                else
                {
                    var resultLogin = new ResultLogin();
                    resultLogin.Token = null;
                    resultLogin.msg = "Login failed!";
                    return resultLogin;
                }
            }
            catch (Exception ex)
            {
                var resultLogin = new ResultLogin();
                resultLogin.Token = null;
                resultLogin.msg = ex.Message;
                return resultLogin;
            }
            
            
        }
    }
}
