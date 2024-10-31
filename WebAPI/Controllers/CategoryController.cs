using Constract.Model;
using Core.Entities;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction.IServices;
using Utility;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        //Get
        [HttpGet("position")]
        public Task<ResponseModel<List<admin_position>>> GetListPosition() => _categoryService.GetPositionAsync().ToResponseModelAsync();
        [HttpGet("country")]
        public Task<ResponseModel<List<admin_country>>> GetListCountry() => _categoryService.GetCountryAsync().ToResponseModelAsync();
        [HttpGet("department")]
        public Task<ResponseModel<List<admin_department>>> GetListDepartment() => _categoryService.GetDepartmentAsync().ToResponseModelAsync();
        [HttpGet("place")]
        public Task<ResponseModel<List<admin_place>>> GetListPlace() => _categoryService.GetPlaceAsync().ToResponseModelAsync();

        //Post
        [HttpPost("position")]
        public Task<ResponseModel<decimal>> PostPosition(admin_position ap) => _categoryService.PostPositionAsync(ap).ToResponseModelAsync();
        [HttpPost("country")]
        public Task<ResponseModel<decimal>> PostCountry(admin_country ac) => _categoryService.PostCountryAsync(ac).ToResponseModelAsync();
        [HttpPost("department")]
        public Task<ResponseModel<decimal>> PostDepartment(admin_department ad) => _categoryService.PostDepartmentAsync(ad).ToResponseModelAsync();
        [HttpPost("place")]
        public Task<ResponseModel<decimal>> PostPlace(admin_place ap) => _categoryService.PostPlaceAsync(ap).ToResponseModelAsync();
    }
}
