using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestStock.BLL.Abstract;
using TestStock.BLL.Repositories.Abstract;
using TestStock.BLL.Repositories.Concrete;
using TestStock.Core.Response;
using TestStock.Dto.CategoryDtos;
using TestStock.Dto.PorductDtos;
using TestStock.Entity;

namespace TestStock.BLL.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }




        public IDataResponse<bool> Add(ProductCreateDto productCreateDto)
        {
            var addedProduc = new Product
            {
                Id=productCreateDto.Id,
                Name= productCreateDto.Name,
               Price=productCreateDto.Price,
               Description=productCreateDto.Description,
               CategoryId=productCreateDto.CategoryId,
            };
            _productRepository.Add(addedProduc);
            return new DataResponse<bool>(true, true, "addedProduc");

        }

        public IDataResponse<bool> Delete(int id)
        {
            var deleteProduct = _productRepository.GetAllByFilter(x => x.Id == id);
            if(deleteProduct == null)
            {
                return new DataResponse<bool>(false, false, "product not found");
            }
          
            return new DataResponse<bool>(true, true, "product silindi");
        }



        public IDataResponse<List<ProductListDto>> GetAllProducts()
        {
            var list = _productRepository.GetAll();
            if(list== null)
            {
                return new DataResponse<List<ProductListDto>>(null, false, "product found");
            }
            foreach(var product in list)
            {
                return new DataResponse<List<ProductListDto>>(null, false, "product not found");

            }
            var productListDto = new List<ProductListDto>();
            foreach (var product in list)
            {
                productListDto.Add(new ProductListDto
                {
                    Id = product.Id,
                    Name=product.Name,


                }); 

            }

            return new DataResponse<List<ProductListDto>>(productListDto,true);

        }
        public IDataResponse<List<ProductListDto>> GetProductsByFilter(Expression<Func<Product, bool>> filter)
        {
            var producList = _productRepository.GetByFilter(filter);
            var productDto = new ProductListDto
            {
                Id = producList.Id,
                Name = producList.Name,

            };
            return DataResponse.
          
        }

        public IDataResponse<ProductListDto> GetProductsById(int Id)
        {
            throw new NotImplementedException();
        }

        public IDataResponse<bool> Update(ProductUpdateDto productUpdateDto)
        {
            throw new NotImplementedException();
        }

        
    }
}
