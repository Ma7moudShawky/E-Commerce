using DTO.DTOs;
using Microsoft.AspNetCore.JsonPatch;

namespace IService.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryDTO>> GetAll();
        public Task<CategoryDTO> Get(int categoryId);
        public Task Add(CategoryDTO categoryDTO);
        public Task Update(CategoryDTO categoryDTO);
        bool CategoryExists(int id);
        Task Delete(int categoryId);
    }
}
