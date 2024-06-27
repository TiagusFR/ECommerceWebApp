using AutoMapper;
using ECommerceWebApp.Controllers.Request;
using ECommerceWebApp.Models;
using ECommerceWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApp.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController(IProductService service, IMapper mapper) : ControllerBase
    {
        private readonly IProductService _service = service;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var product = _service.GetById(id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post(ProductRequestDTO request)
        {
            var result = _service.Add(_mapper.Map<Product>(request));

            return CreatedAtAction(nameof(GetById), new { id = result.ProductId }, result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, UpdateProductRequestDTO request)
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