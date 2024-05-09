using Application.Authentication;
using Constract.Authentication;
using Core.Dtos.Authorization;
using Core.Dtos.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private JwtSetting _jwtSettings;
        public AccountController(JwtSetting jwtSettings) : base()
        {
            _jwtSettings = jwtSettings;
        }
        [HttpPost]
        [Route("Login")]
        //[AllowAnonymous]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var tokenModel = new JwtUserTokens();
            var result = new ResultLogin();
            tokenModel = JwtHelpers.GenTokenkey(new JwtUserTokens()
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
            result.Token = JsonConvert.SerializeObject(tokenModel);
            return Ok(tokenModel);
        }
    }
}
