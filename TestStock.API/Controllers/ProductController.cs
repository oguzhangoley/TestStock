using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestStock.BLL.Abstract;
using TestStock.Dto.PorductDtos;

namespace TestStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;

        }
        [HttpGet("products")]
        public IActionResult GetAllProducts()
        {
            var producs = _productService.GetAllProducts();
            return Ok(producs);
        }

        [HttpGet("product")]
        public IActionResult GetProductById(int id)
        {
            var produc = _productService.GetProductById(id);
            return Ok(produc);
        }

        [HttpPost("adedproduct")]
        public IActionResult addProduct(ProductCreateDto productCreateDto)
        {
            var produc = _productService.Add(productCreateDto);
            return Ok(produc);
        }


        [HttpPost("updateProcuct")]
        public IActionResult update(ProductUpdateDto productUpdateDto)
        {
            var produc = _productService.Update(productUpdateDto);
            return Ok(produc);
        }

        [HttpPost("deleteProcuct")]
        public IActionResult delete(int id)
        {
            var produc = _productService.Delete(id);
            return Ok(produc);
        }




    }

}
