using DbModels.Models;
using DTO.DTOs;

namespace IRepo.Interfaces
{
    public interface ICategoryRepo
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> Get(int id, bool isTracked = false);
        Task Add(CategoryDTO categoryDTO);
        Task Update(CategoryDTO categoryDTO);
        bool CategoryExists (int id);
        Task Delete(int categoryId);
    }
}
