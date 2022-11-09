using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestStock.BLL.Abstract;
using TestStock.Dto.CategoryDtos;

namespace TestStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        // Kategori ile ilgili işlemler bu controller da olacak

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("categoryGet")]
        public IActionResult GetCategories()
        {
            var result = _categoryService.GetAllCategoris();
            return Ok(result);
        }

        [HttpGet("category")]
        public IActionResult GetCategoryById(int categoryId)
        {
            var result = _categoryService.GetCategoryById(categoryId);
            return Ok(result);
        }

        [HttpPost("addcategory")]
        public IActionResult AddCategory(CategoryCreateDto categoryCreateDto)
        {
            var result = _categoryService.Add(categoryCreateDto);
            return Ok(result);
        }

        [HttpPost("updatecategory")]
        public IActionResult UpdateCategory(CategoryUpdateDto categoryUpdateDto)
        {
            var result = _categoryService.Update(categoryUpdateDto);
            return Ok(result);
        }

        [HttpPost("deletecategory")]
        public IActionResult DeleteCategory(int categoryId)
        {
            var result = _categoryService.Delete(categoryId);
            return Ok(result);
        }
    }
}
