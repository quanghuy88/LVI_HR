using Application.Authentication;
using Application.Services;
using Constract.Authentication;
using Core.Dtos.Authorization;
using Core.Dtos.Jwt;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.Abstraction.IServices;
using Utility;

namespace WebAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authenService;

        private JwtSetting _jwtSettings;
        public AccountController(JwtSetting jwtSettings, IAuthenticationService autenService) : base()
        {
            _jwtSettings = jwtSettings;
            _authenService = autenService;
        }
        [HttpPost("Login")]
        public Task<ResponseModel<ResultLogin>> Login(LoginRequest request) => _authenService.LoginAsync(request).ToResponseModelAsync();
        //public async Task<ResponseModel<JwtUserTokens>> Login(LoginRequest request)
        //{
        //    var tokenModel = new JwtUserTokens();
        //    var result = new ResultLogin();
        //    tokenModel = JwtHelpers.GenTokenkey(new JwtUserTokens()
        //    {
        //        GuidId = Guid.NewGuid(),
        //        UserName = request.UserName,
        //        Id = '1',
        //        Name = request.UserName,
        //        DepartmentID = '1',
        //        DepartmentName = "cntt",
        //        BranchId = '2',
        //        BranchCode = "ho",
        //        BranchName = "ho",
        //        Role = null,
        //        AccountMonthId = 1,
        //        AccountMonthCode = "",
        //        LstPermission = null,
        //    }, _jwtSettings);
        //    result.Token = JsonConvert.SerializeObject(tokenModel);
        //    return Ok(tokenModel);
        //}
    }
}
