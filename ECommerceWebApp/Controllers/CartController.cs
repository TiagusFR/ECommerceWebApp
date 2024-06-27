using AutoMapper;
using ECommerceWebApp.Controllers.Request;
using ECommerceWebApp.Models;
using ECommerceWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApp.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController(ICartService service, IMapper mapper) : ControllerBase
    {
        private readonly ICartService _service = service;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var cart = _service.GetById(id);

            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        [HttpPost]
        public IActionResult Post(CartRequestDTO request)
        {
            var result = _service.Add(_mapper.Map<Cart>(request));

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, UpdateCartRequestDTO request)
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
