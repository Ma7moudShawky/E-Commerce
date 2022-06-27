using DTO.DTOs;

namespace IService.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAll();
    }
}
