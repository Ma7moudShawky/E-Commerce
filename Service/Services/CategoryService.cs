using DTO.DTOs;
using IRepo.Interfaces;
using IService.Interfaces;

namespace Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoryService(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            var dbCategories = await _categoryRepo.GetAll();
            var categoryDtos = dbCategories.Select(x => new CategoryDTO
            {
                CategoryId = x.CategoryId,
                CategoryName = x.Name
            });

            //foreach (var dbCategory in dbCategories)
            //{
            //    categoryDtos.Add(new CategoryDTO()
            //    {
            //        CategoryId = dbCategory.CategoryId,
            //        CategoryName = dbCategory.Name
            //    });
            //}

            return categoryDtos;
        }
    }
}
