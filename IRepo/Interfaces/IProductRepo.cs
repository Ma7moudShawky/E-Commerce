using DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepo.Interfaces
{
    public interface IProductRepo
    {
        public Task Add(ProductDTO productDTO);
        public Task<IEnumerable<ProductDTOToReturn>> GetAll();
        public Task<ProductDTOToReturn> Get(int id, bool isTracked = false, bool includeCategory = false);
        public Task Update(ProductDTOToReturn productDTO);
        public Task<bool> ProductExists(int productId);
        public Task Delete(int productId);
    }
}
