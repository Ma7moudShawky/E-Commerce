using DTO.DTOs;
using IRepo.Interfaces;
using IService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;

        public ProductService(IProductRepo productRepo)
        {
            _productRepo = productRepo ?? throw new ArgumentNullException(nameof(productRepo));
        }


        public async Task Add(ProductDTO productDTO)
        {
            await _productRepo.Add(productDTO);
        }

        public async Task Delete(int productId)
        {
            await _productRepo.Delete(productId);
        }

        public Task<ProductDTOToReturn> Get(int id, bool isTracked = false, bool includeCategory = false)
        {
            return _productRepo.Get(id, isTracked, includeCategory);
        }

        public async Task<IEnumerable<ProductDTOToReturn>> GetAll()
        {
            IEnumerable<ProductDTOToReturn> result = await _productRepo.GetAll();
            return result;
        }

        public async Task<bool> ProductExists(int productId)
        {
            return await _productRepo.ProductExists(productId);
        }

        public async Task Update(ProductDTOToReturn productDTO)
        {
            await _productRepo.Update(productDTO);
        }
    }
}
