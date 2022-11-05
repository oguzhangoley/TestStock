using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestStock.Core.Response;
using TestStock.Dto.CategoryDtos;
using TestStock.Entity;

namespace TestStock.BLL.Abstract
{
    public interface ICategoryService
    {
        IDataResponse<bool> Add(CategoryCreateDto categoryCreateDto);
        IDataResponse<bool> Update(CategoryUpdateDto categoryUpdateDto);
        IDataResponse<bool> Delete(int id);
        IDataResponse<List<CategoryListDto>> GetAllCategoris();
        IDataResponse<List<CategoryListDto>> GetCategoriesByFilter(Expression<Func<Category,bool>> filter);
        IDataResponse<CategoryListDto> GetCategoryById(int categoryId);
        IDataResponse<CategoryListDto> GetCategoryByFilter(Expression<Func<Category, bool>> filter);

    }
}
