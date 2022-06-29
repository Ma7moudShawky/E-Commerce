using AutoMapper;
using DTO.DTOs;
using E_Commerce.ViewModels.Product;
using IService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, ICategoryService categoryService, IMapper mapper)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        [ProducesResponseType(202)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Add(AddOrUpdateProduct addedProduct)
        {
            try
            {
                if (!await _categoryService.CategoryExists(addedProduct.CategoryId))
                {
                    return NotFound();
                }
                ProductDTO productDTO = _mapper.Map<ProductDTO>(addedProduct);
                await _productService.Add(productDTO);
                return Created("", null);
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }

        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProductViewModel>))]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                IEnumerable<ProductDTOToReturn> products = await _productService.GetAll();
                IEnumerable<ProductViewModel> result = _mapper.Map<IEnumerable<ProductViewModel>>(products);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }


        [HttpGet("{productId}")]
        [ProducesResponseType(200, Type = typeof(ProductViewModel))]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Get(int productId)
        {
            try
            {
                ProductDTOToReturn product = await _productService.Get(productId);
                if (product == null)
                {
                    return NotFound();
                }
                ProductViewModel result = _mapper.Map<ProductViewModel>(product);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPut("{productId}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<ActionResult> Update(int productId, AddOrUpdateProduct updatedProduct)
        {
            try
            {
                ProductDTOToReturn productDTOToReturn = await _productService.Get(productId);
                if (productDTOToReturn == null)
                {
                    return NotFound();
                }
                productDTOToReturn = _mapper.Map<ProductDTOToReturn>(updatedProduct);
                productDTOToReturn.Category = new CategoryDTO() { CategoryId = updatedProduct.CategoryId };
                productDTOToReturn.ProductId = productId;
                await _productService.Update(productDTOToReturn);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete("{productId}")]
        public async Task<ActionResult> Delete(int productId)
        {
            try
            {
                if (!await _productService.ProductExists(productId))
                {
                    return NotFound();
                }
                await _productService.Delete(productId);
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
