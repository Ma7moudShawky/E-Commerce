using AutoMapper;
using DTO.DTOs;
using E_Commerce.ViewModels.Category;

namespace E_Commerce.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDTO, CategoryViewModel>();
        }
    }
}
