using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestStock.BLL.Abstract;
using TestStock.BLL.Repositories.Abstract;
using TestStock.Core.Response;
using TestStock.Dto.PorductDtos;
using TestStock.Entity;

namespace TestStock.BLL.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductManager(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IDataResponse<bool> Add(ProductCreateDto productCreateDto)
        {
            try
            {
                var addedProduct = new Product()
                {
                    Name = productCreateDto.Name,
                    UnitPrice = productCreateDto.UnitPrice,
                    UnitInStock = productCreateDto.UnitInStock,
                    CategoryId = productCreateDto.CategoryId,

                };
                _productRepository.Add(addedProduct);
                return new DataResponse<bool>(true, true, "product added");
            }
            catch (Exception e)
            {

                return new DataResponse<bool>(false, false, e.Message);
            }
           
        }

        public IDataResponse<bool> Delete(int id)
        {
            try
            {
                var deletedProduct = _productRepository.GetByFilter(x => x.Id == id);
                if (deletedProduct == null)
                {
                    return new DataResponse<bool>(false, false, "product not found");
                }
                _productRepository.Update(deletedProduct);
                return new DataResponse<bool>(true, true, "product deleted");
            }
            catch (Exception e)
            {

                return new DataResponse<bool>(false,false, e.Message);
            }
           
        }

        public IDataResponse<List<ProductListDto>> GetAllProducts()
        {
            try
            {
                var products = _productRepository.GetAll();
                if (products == null)
                {
                    return new DataResponse<List<ProductListDto>>(null, false, "categories not found");
                }
                var productListDto = new List<ProductListDto>();
                foreach (var product in products)
                {
                    productListDto.Add(new ProductListDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        UnitInStock = product.UnitInStock,
                        CategoryName = _categoryRepository.GetByFilter(x => x.CategoryId == product.CategoryId).CategoryName,
                        UnitPrice = product.UnitPrice
                    });
                }
                return new DataResponse<List<ProductListDto>>(productListDto, true);
            }
            catch (Exception e)
            {

                return new DataResponse<List<ProductListDto>> (null, false, e.Message);
            }
          
        }

        public IDataResponse<List<ProductListDto>> GetCategoriesByFilter(Expression<Func<Product, bool>> filter)
        {
            try
            {
                var products = _productRepository.GetAllByFilter(filter);
                if (products == null)
                {
                    return new DataResponse<List<ProductListDto>>(null, false, "products not found");
                }
                var productsListDto = new List<ProductListDto>();
                foreach (var product in products)
                {
                    productsListDto.Add(new ProductListDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        UnitInStock = product.UnitInStock,
                        CategoryName = _categoryRepository.GetByFilter(x => x.CategoryId == product.CategoryId).CategoryName,
                        UnitPrice = product.UnitPrice
                    });
                }
                return new DataResponse<List<ProductListDto>>(productsListDto, true);
            }
            catch (Exception e)
            {

                return new DataResponse<List<ProductListDto>>(null,false, e.Message);
            }
            
        }

        public IDataResponse<ProductListDto> GetProductById(int productId)
        {
            try
            {
                var product = _productRepository.GetByFilter(x => x.Id == productId);
                var productListDto = new ProductListDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    UnitInStock = product.UnitInStock,
                    CategoryName = _categoryRepository.GetByFilter(x => x.CategoryId == product.CategoryId).CategoryName,
                    UnitPrice = product.UnitPrice

                };
                return new DataResponse<ProductListDto>(productListDto, true);
            }
            catch (Exception e)
            {

                return new DataResponse<ProductListDto>(null,false, e.Message);
            }
           
        }

        public IDataResponse<bool> Update(ProductUpdateDto productUpdateDto)
        {
            var product = _productRepository.GetByFilter(x => x.Id == productUpdateDto.Id);
            product.Name = productUpdateDto.Name;
            product.UnitInStock = productUpdateDto.UnitInStock;
            product.UnitPrice = productUpdateDto.UnitPrice;
            product.CategoryId= productUpdateDto.CategoryId;
            
            _productRepository.Update(product);
            return new DataResponse<bool>(true, true, "product updated");
        }
    }
}
