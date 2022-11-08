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
        // Product ile ilgili işlemler bu controller da olacak
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet("productsGetAll")]
        public IActionResult GetProduct()
        {
            var result = _productService.GetAllProducts();
            return Ok(result);
        }

        [HttpGet("productgetbyId")]
        public IActionResult GetProductById(int productId)
        {
            var result = _productService.GetProductById(productId);
            return Ok(result);
        }

        [HttpPost("productsGetAll")]
        public IActionResult AddedProduct(ProductCreateDto productCreateDto)
        {
            var result = _productService.Add(productCreateDto);
            return Ok(result);
        }

        [HttpPost("productUpdate")]
        public IActionResult UpdateProduct(ProductUpdateDto productUpdateDto)
        {
            var result = _productService.Update(productUpdateDto);
            return Ok(result);
        }

        [HttpPost("productDelete")]
        public IActionResult DeleteProduct(int productId)
        {
            var result = _productService.Delete(productId);
            return Ok(result);
        }
    }
}
