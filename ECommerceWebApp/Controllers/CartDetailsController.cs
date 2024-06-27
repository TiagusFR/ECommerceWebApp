using AutoMapper;
using ECommerceWebApp.Controllers.Request;
using ECommerceWebApp.Models;
using ECommerceWebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApp.Controllers
{
    [Route("api/cartDetail")]
    [ApiController]
    public class CartDetailController(ICartDetailService service, IMapper mapper) : ControllerBase
    {
        private readonly ICartDetailService _service = service;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var cartDetail = _service.GetById(id);

            if (cartDetail == null)
            {
                return NotFound();
            }
            return Ok(cartDetail);
        }

        [HttpPost]
        public IActionResult Post(CartDetailRequestDTO request)
        {
            var result = _service.Add(_mapper.Map<CartDetail>(request));

            return CreatedAtAction(nameof(GetById), new { dd = result.Id }, result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, UpdateCartDetailRequestDTO request)
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