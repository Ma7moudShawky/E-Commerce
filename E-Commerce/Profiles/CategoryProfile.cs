using AutoMapper;
using DbModels.Models;
using DTO.DTOs;
using E_Commerce.ViewModels.Category;

namespace E_Commerce.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDTO, CategoryViewModel>();
            CreateMap<AddOrUpdateCategory, CategoryDTO>();
            CreateMap<CategoryDTO, AddOrUpdateCategory>();
            CreateMap<AddOrUpdateCategory, CategoryDTO>();
            CreateMap<Category, CategoryDTO>().ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Name));
            CreateMap<CategoryDTO, Category>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CategoryName));
        }
    }
}
