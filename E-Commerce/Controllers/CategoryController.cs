using AutoMapper;
using DTO.DTOs;
using E_Commerce.ViewModels.Category;
using IService.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
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
            try
            {
                var categories = await _categoryService.GetAll();

                IEnumerable<CategoryViewModel> result = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);

                return Ok(result);
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }

        }
        [HttpGet("{categoryId}", Name = "GetCategory")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(CategoryViewModel))]
        public async Task<ActionResult> Get(int categoryId)
        {
            try
            {
                CategoryDTO categoryDTO = await _categoryService.Get(categoryId);
                if (categoryDTO == null)
                {
                    return NotFound();
                }
                CategoryViewModel categoryViewModel = _mapper.Map<CategoryViewModel>(categoryDTO);
                return Ok(categoryViewModel);
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }
        [HttpPost]
        [ProducesResponseType(202, Type = typeof(CategoryViewModel))]
        public async Task<ActionResult> Add(AddOrUpdateCategory addedCategory)
        {
            try
            {
                CategoryDTO categoryDTO = _mapper.Map<CategoryDTO>(addedCategory);
                await _categoryService.Add(categoryDTO);
                return Created("", null);
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }
        [HttpPut("{categoryId}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<ActionResult> Update(int categoryId, AddOrUpdateCategory addOrUpdateCategory)
        {
            try
            {
                if (!_categoryService.CategoryExists(categoryId))
                {
                    return NotFound();
                }
                CategoryDTO updatedCategory = _mapper.Map<CategoryDTO>(addOrUpdateCategory);
                updatedCategory.CategoryId = categoryId;
                await _categoryService.Update(updatedCategory);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }
        [HttpPatch("{categoryId}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<ActionResult> Update(int categoryId, JsonPatchDocument<AddOrUpdateCategory> patchDocument)
        {
            try
            {
                CategoryDTO categoryToUpdate = await _categoryService.Get(categoryId);
                if (categoryToUpdate == null)
                {
                    return NotFound();
                }
                AddOrUpdateCategory updatedCategory = _mapper.Map<AddOrUpdateCategory>(categoryToUpdate);
                patchDocument.ApplyTo(updatedCategory, ModelState);
                if (!ModelState.IsValid || !TryValidateModel(updatedCategory))
                {
                    return BadRequest(ModelState);
                }
                _mapper.Map(updatedCategory, categoryToUpdate);
                categoryToUpdate.CategoryId = categoryId;
                await _categoryService.Update(categoryToUpdate);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }
        [HttpDelete("{categoryId}")]
        public async Task<ActionResult> Delete(int categoryId)
        {
            try
            {
                if (!_categoryService.CategoryExists(categoryId))
                {
                    return NotFound();
                }
                await _categoryService.Delete(categoryId);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
