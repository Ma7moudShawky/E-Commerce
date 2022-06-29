using AutoMapper;
using DbModels.Models;
using DTO.DTOs;
using IRepo.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Repos
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public ProductRepo(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }



        public async Task Add(ProductDTO productDTO)
        {
            Product addedProduct = _mapper.Map<Product>(productDTO);
            _appDbContext.Products.Add(addedProduct);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(int productId)
        {
            Product productToDelete = new Product() { ProductId = productId };
            _appDbContext.Products.Attach(productToDelete);
            _appDbContext.Products.Remove(productToDelete);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<ProductDTOToReturn> Get(int id, bool isTracked = false, bool includeCategory = false)
        {
            var dbSet = isTracked ? _appDbContext.Products : _appDbContext.Products.AsNoTracking();

            dbSet = includeCategory ? dbSet.Include(p => p.Category) : dbSet;

            Product product = await dbSet.Include(p => p.Category).FirstOrDefaultAsync(p => p.ProductId == id);
            ProductDTOToReturn productDTOToReturn = _mapper.Map<ProductDTOToReturn>(product);
            return productDTOToReturn;
        }

        public async Task<IEnumerable<ProductDTOToReturn>> GetAll()
        {
            List<Product> products = await _appDbContext.Products.AsNoTracking().Include(p => p.Category).ToListAsync();
            //List<Product> products = await _appDbContext.Products.ToListAsync();
            List<ProductDTOToReturn> result = _mapper.Map<List<ProductDTOToReturn>>(products);
            return result;
        }

        public async Task<bool> ProductExists(int productId)
        {
            return await _appDbContext.Products.AnyAsync(p => p.ProductId == productId);
        }

        public async Task Update(ProductDTOToReturn productDTO)
        {
            Product updatedProduct = _mapper.Map<Product>(productDTO);
            EntityEntry<Product> entity = _appDbContext.Entry(updatedProduct);
            entity.State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }
    }
}
