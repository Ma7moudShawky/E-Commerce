using AutoMapper;
using E_Commerce.ViewModels.Category;
using IService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CategoryViewModel>))]
        public async Task<ActionResult> GetAll()
        {
            var categories = await _categoryService.GetAll();

            IEnumerable<CategoryViewModel> result = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);

            return Ok(result);
        }
    }
}
