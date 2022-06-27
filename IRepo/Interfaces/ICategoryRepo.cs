using DbModels.Models;

namespace IRepo.Interfaces
{
    public interface ICategoryRepo
    {
        Task<IEnumerable<Category>> GetAll();
    }
}
