using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestStock.Core.Response;
using TestStock.Dto.PorductDtos;
using TestStock.Entity;

namespace TestStock.BLL.Abstract
{
    public interface IProductService
    {
        IDataResponse<bool> Add(ProductCreateDto productCreateDto);
        IDataResponse<bool> Update(ProductUpdateDto productUpdateDto);
        IDataResponse<bool> Delete(int id);
        IDataResponse<List<ProductListDto>> GetAllProducts();
        IDataResponse<List<ProductListDto>> GetCategoriesByFilter(Expression<Func<Product, bool>> filter);
        IDataResponse<ProductListDto> GetProductById(int productId);

    }
}
