using AutoMapper;
using DbModels.Models;
using DTO.DTOs;
using IRepo.Interfaces;
using IService.Interfaces;
using Microsoft.AspNetCore.JsonPatch;

namespace Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepo categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo ?? throw new ArgumentNullException(nameof(categoryRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Add(CategoryDTO categoryDTO)
        {
            await _categoryRepo.Add(categoryDTO);
        }

        public async Task<bool> CategoryExists(int id)
        {
            return await _categoryRepo.CategoryExists(id);
        }

        public async Task Delete(int categoryId)
        {
            await _categoryRepo.Delete(categoryId);
        }

        public async Task<CategoryDTO> Get(int categoryId, bool isTracked = false, bool includeProducts = false)
        {
            var category = await _categoryRepo.Get(categoryId, isTracked, includeProducts);
            CategoryDTO categoryDTO = _mapper.Map<CategoryDTO>(category);
            return categoryDTO;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            var dbCategories = await _categoryRepo.GetAll();
            IEnumerable<CategoryDTO> categoryDtos = _mapper.Map<IEnumerable<CategoryDTO>>(dbCategories);
            return categoryDtos;
        }

        public async Task Update(CategoryDTO categoryDTO)
        {
            await _categoryRepo.Update(categoryDTO);
        }


    }
}
