using AutoMapper;
using DbModels.Models;
using DTO.DTOs;
using E_Commerce.ViewModels.Product;

namespace E_Commerce.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();
            CreateMap<AddProduct, ProductDTO>();
            CreateMap<Product, ProductDTOToReturn>();
            CreateMap<ProductDTOToReturn, ProductViewModel>();
            CreateMap<AddProduct, ProductDTOToReturn>();
            CreateMap<ProductDTOToReturn, Product>().ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.CategoryId));
            CreateMap<UpdateProduct, ProductDTOToReturn>();        
        }
    }
}
