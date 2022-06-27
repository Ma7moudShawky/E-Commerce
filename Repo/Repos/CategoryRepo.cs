using DbModels.Models;
using IRepo.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repo.Model;

namespace Repo.Repos
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var categories = _appDbContext.Categories.AsNoTracking();
            return await categories.ToListAsync();
        }
    }
}
