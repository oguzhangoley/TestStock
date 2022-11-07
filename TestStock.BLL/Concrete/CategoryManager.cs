using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestStock.BLL.Abstract;
using TestStock.BLL.Repositories.Abstract;
using TestStock.Core.Response;
using TestStock.Dto.CategoryDtos;
using TestStock.Entity;

namespace TestStock.BLL.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IDataResponse<bool> Add(CategoryCreateDto categoryCreateDto)
        {
            var addedCategory = new Category
            {
                CategoryName = categoryCreateDto.CategoryName,
                Status = true
            };
            _categoryRepository.Add(addedCategory);
            return new DataResponse<bool>(true, true,"category added");
        }

        public IDataResponse<bool> Delete(int id)
        {
            var deletedCategory = _categoryRepository.GetByFilter(x => x.CategoryId == id);
            if(deletedCategory == null)
            {
                return new DataResponse<bool>(false, false, "category not found");
            }
            deletedCategory.Status = false;
            _categoryRepository.Update(deletedCategory);
            return new DataResponse<bool> (true,true, "category deleted");
        }

        public IDataResponse<List<CategoryListDto>> GetAllCategoris()
        {
            var categories = _categoryRepository.GetAll();
            if(categories == null)
            {
                return new DataResponse<List<CategoryListDto>>(null, false, "categories not found");
            }
            var categoriesListDto = new List<CategoryListDto>();
            foreach (var category in categories)
            {
                categoriesListDto.Add(new CategoryListDto
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName
                });
            }
            return new DataResponse<List<CategoryListDto>>(categoriesListDto,true);
        }

        public IDataResponse<List<CategoryListDto>> GetCategoriesByFilter(Expression<Func<Category, bool>> filter)
        {
            var categories = _categoryRepository.GetAllByFilter(filter);
            if (categories == null)
            {
                return new DataResponse<List<CategoryListDto>>(null, false, "categories not found");
            }
            var categoriesListDto = new List<CategoryListDto>();
            foreach (var category in categories)
            {
                categoriesListDto.Add(new CategoryListDto
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName
                });
            }
            return new DataResponse<List<CategoryListDto>>(categoriesListDto, true);
        }

        public IDataResponse<CategoryListDto> GetCategoryByFilter(Expression<Func<Category, bool>> filter)
        {
            var category = _categoryRepository.GetByFilter(filter);
            var categoryListDto = new CategoryListDto
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
            return new DataResponse<CategoryListDto>(categoryListDto, true);
        }

        public IDataResponse<CategoryListDto> GetCategoryById(int categoryId)
        {
            var category = _categoryRepository.GetByFilter(x=>x.CategoryId == categoryId);
            var categoryListDto = new CategoryListDto
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
            return new DataResponse<CategoryListDto>(categoryListDto, true);
        }

        public IDataResponse<bool> Update(CategoryUpdateDto categoryUpdateDto)
        {
            var category = _categoryRepository.GetByFilter(x => x.CategoryId == categoryUpdateDto.CategoryId);
            category.CategoryName = categoryUpdateDto.CategoryName;
            _categoryRepository.Update(category);
            return new DataResponse<bool>(true, true, "category updated");
        }
    }
}
