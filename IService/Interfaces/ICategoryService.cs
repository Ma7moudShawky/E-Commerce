using DTO.DTOs;
using Microsoft.AspNetCore.JsonPatch;

namespace IService.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryDTO>> GetAll();
        public Task<CategoryDTO> Get(int categoryId, bool isTracked = false, bool includeProducts = false);
        public Task Add(CategoryDTO categoryDTO);
        public Task Update(CategoryDTO categoryDTO);
        public Task<bool> CategoryExists(int id);
        public Task Delete(int categoryId);
    }
}
