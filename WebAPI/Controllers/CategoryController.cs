using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction.IServices;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("classgroup")]
        public async Task<IActionResult> GetListProduct() => Ok(_categoryService.GetClassGroup());
        [HttpGet]
        [Route("branch")]
        public async Task<IActionResult> GetListBranch() => Ok(_categoryService.GetBranch());
    }
}
