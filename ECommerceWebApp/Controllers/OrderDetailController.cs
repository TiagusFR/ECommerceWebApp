using AutoMapper;
using ECommerceWebApp.Controllers.Request;
using ECommerceWebApp.Models;
using ECommerceWebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApp.Controllers
{
    [Route("api/orderDetail")]
    [ApiController]
    public class OrderDetailController(IOrderDetailService service, IMapper mapper) : ControllerBase
    {
        private readonly IOrderDetailService _service = service;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var orderDetail = _service.GetById(id);

            if (orderDetail == null)
            {
                return NotFound();
            }
            return Ok(orderDetail);
        }

        [HttpPost]
        public IActionResult Post(OrderDetailRequestDTO request)
        {
            var result = _service.Add(_mapper.Map<OrderDetail>(request));

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, UpdateOrderDetailRequestDTO request)
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
