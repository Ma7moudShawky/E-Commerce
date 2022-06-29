using DTO.DTOs;

namespace IService.Interfaces
{
    public interface IProductService
    {
        public Task Add(ProductDTO productDTO);
        public Task<IEnumerable<ProductDTOToReturn>> GetAll();
        public Task<ProductDTOToReturn> Get(int id, bool isTracked = false, bool includeCategory = false);
        public Task Update(ProductDTOToReturn productDTO);
        public Task<bool> ProductExists(int productId);
        public Task Delete(int productId);
    }
}
