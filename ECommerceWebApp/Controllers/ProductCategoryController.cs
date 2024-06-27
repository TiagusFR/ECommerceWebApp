using AutoMapper;
using ECommerceWebApp.Controllers.Request;
using ECommerceWebApp.Models;
using ECommerceWebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApp.Controllers
{
    [Route("api/productCategory")]
    [ApiController]
    public class ProductCategoryController(IProductCategoryService service, IMapper mapper) : ControllerBase
    {
        private readonly IProductCategoryService _service = service;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var productCateogry = _service.GetById(id);

            if (productCateogry == null)
            {
                return NotFound();
            }
            return Ok(productCateogry);
        }

        [HttpPost]
        public IActionResult Post(ProductCategoryRequestDTO request)
        {
            var result = _service.Add(_mapper.Map<ProductCategory>(request));

            return CreatedAtAction(nameof(GetById), new { id = result.CategoryId }, result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, UpdateProductCategoryRequestDTO request)
        {
            _service.Update(id, request);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _service.Delete(id);

            return NoContent();
        }
    }
}
