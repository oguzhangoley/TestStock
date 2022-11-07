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
            var result=_productService.GetAllProducts();
            return Ok(result);
        }

        [HttpGet("Product getById ")]
        public IActionResult GetActionById(int productId)
        {
            var result = _productService.GetProductById(productId);
            return Ok(result);
        }


        [HttpPost("addProduct")]
        public IActionResult AddProduct(ProductCreateDto dto)
        {
            var result = _productService.Add(dto);
            return Ok(result);
            

        }

        [HttpPost("updateProduct")]
        public IActionResult UpdateProduct(ProductUpdateDto dto)
        {
            var reuslt = _productService.Update(dto);
            return Ok(reuslt);
        }

        [HttpPost("deleteProduct")]
        public IActionResult DeleteProduct(int productId)
        {
            var result = _productService.Delete(productId);
            return Ok(result);
        }
    }
    
}
