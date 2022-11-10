using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TestStock.BLL.Abstract;
using TestStock.BLL.Repositories.Abstract;
using TestStock.Core.Response;
using TestStock.Dto.CategoryDtos;
using TestStock.Dto.OrderDtos;
using TestStock.Dto.PorductDtos;
using TestStock.Entity;

namespace TestStock.BLL.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IOrderService _orderService;
        public ProductManager(IProductRepository productRepository, ICategoryRepository categoryRepository/* IOrderService orderService*/)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            //_orderService = orderService;
        }

        public IDataResponse<bool> Add(ProductCreateDto productCreateDto)
        {
            var addedProduct = new Product { 
            
             Name = productCreateDto.Name,
             Description = productCreateDto.Description,
             Price = productCreateDto.Price,
             Stock = productCreateDto.Stock,
             CategoryId = productCreateDto.CategoryId,

            };
            _productRepository.Add(addedProduct);
            return new DataResponse<bool>(true, true, "product added");
        }

        public IDataResponse<bool> Delete(int id)
        {
            var deletedProduct= _productRepository.GetByFilter(x=>x.Id == id);
            if (deletedProduct ==null)
            {
                return new DataResponse<bool>(false, false, "product not found. ");
            }
           _productRepository.Delete(deletedProduct);
            return new DataResponse<bool>(true, true, "product deleted");
            
        }

        public IDataResponse<List<ProductListDto>> GetAllProducts()
        {
           
           var products = _productRepository.GetAll();
            if (products== null)
            {
                return new DataResponse<List<ProductListDto>>(null, false, "products not found");
            }
            var productsListDto=new List<ProductListDto>();
            foreach (var product in products)
            {
                ProductListDto productListDto=new ProductListDto();
                productsListDto.Add(new ProductListDto
                {
                    Id = product.Id,
                    Name=product.Name,
                    Description=product.Description,
                    Price=product.Price,    
                    Stock=product.Stock,
    
                    CategoryId=product.CategoryId,
                });

            }
            return new DataResponse<List<ProductListDto>>(productsListDto, true);

        }





        public IDataResponse<List<ProductListDto>> GetProductByFilter(Expression<Func<Product, bool>> filter)
        {
            var products = _productRepository.GetAllByFilter(filter);
            if (products==null)
            {
                return new DataResponse<List<ProductListDto>>(null, false, "product not found");
            }

            var productsListDto=new List<ProductListDto>();
            foreach (var product in products)
            {
                productsListDto.Add(new ProductListDto
                {
                    Id=product.Id,
                    Description=product.Description,
                    Price = product.Price,
                    Stock = product.Stock,  
                    CategoryId = product.CategoryId,

                });
            }
            return new DataResponse<List<ProductListDto>>(productsListDto, true);

        }

        public IDataResponse<ProductListDto> GetProductById(int productId)
        {
            var product= _productRepository.GetByFilter(x=>x.Id==productId);
            var productListDto = new ProductListDto //
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId,
            };
            return new DataResponse<ProductListDto>(productListDto, true);
        }

        public IDataResponse<bool> Update(ProductUpdateDto productUpdateDto)
        {
            var product = _productRepository.GetByFilter(x=>x.Id==productUpdateDto.Id);
            if (product!=null)
            {
                _productRepository.Update(new()
                {
                    Id = product.Id,
                    Description = product.Description,
                    Price = product.Price,
                    Stock = product.Stock,
                    CategoryId = product.CategoryId,
                });

                return new DataResponse<bool>( true, true, "category updated");
            }
            return new DataResponse<bool>(true,false, "product not found");
        }
    }
}
