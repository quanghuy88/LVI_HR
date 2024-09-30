using Constract.Model;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet("classgroup")]
        public Task<ResponseModel<List<class_group_model>>> GetListProduct() => _categoryService.GetClassGroupAsync().ToResponseModelAsync();
        [HttpGet("branch")]
        public Task<ResponseModel<List<branch_model>>> GetListBranch() => _categoryService.GetBranchAsync().ToResponseModelAsync();
    }
}
