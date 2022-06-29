using AutoMapper;
using DbModels.Models;
using DTO.DTOs;
using IRepo.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repo.Model;

namespace Repo.Repos
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public CategoryRepo(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task Add(CategoryDTO categoryDTO)
        {
            Category addedCategory = _mapper.Map<Category>(categoryDTO);
            _appDbContext.Categories.Add(addedCategory);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<bool> CategoryExists(int id)
        {
            return await _appDbContext.Categories.AnyAsync(c => c.CategoryId == id);
        }

        public async Task Delete(int categoryId)
        {
            Category deletedCategory = await Get(categoryId);
            _appDbContext.Categories.Remove(deletedCategory);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Category> Get(int id, bool isTracked = false, bool includeProducts = false)
        {
            var dbSet = isTracked ? _appDbContext.Categories : _appDbContext.Categories.AsNoTracking();
            dbSet = includeProducts ? dbSet.Include(c => c.Products) : dbSet;
            Category category = await dbSet.FirstOrDefaultAsync(c => c.CategoryId == id);
            return category;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var categories = _appDbContext.Categories.AsNoTracking();
            return await categories.ToListAsync();
        }

        public async Task Update(CategoryDTO categoryDTO)
        {
            Category updatedCategory = _mapper.Map<Category>(categoryDTO);
            EntityEntry<Category> entryCategory = _appDbContext.Entry(updatedCategory);
            entryCategory.State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            //Category updatedCategory = await Get(categoryDTO.CategoryId);
            //_mapper.Map(categoryDTO, updatedCategory);
            ////updatedCategory = _mapper.Map<Category>(categoryDTO);
            //await _appDbContext.SaveChangesAsync();
        }
    }
}
