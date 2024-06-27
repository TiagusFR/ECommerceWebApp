using AutoMapper;
using ECommerceWebApp.Controllers.Request;
using ECommerceWebApp.Models;
using ECommerceWebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApp.Controllers
{
    [Route("api/orderStatus")]
    [ApiController]
    public class OrderStatusController(IOrderStatusService service, IMapper mapper) : ControllerBase
    {
        private readonly IOrderStatusService _service = service;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var orderStatus = _service.GetById(id);

            if (orderStatus == null)
            {
                return NotFound();
            }
            return Ok(orderStatus);
        }

        [HttpPost]
        public IActionResult Post(OrderStatusRequestDTO request)
        {
            var result = _service.Add(_mapper.Map<OrderStatus>(request));

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, UpdateOrderStatusRequestDTO request)
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
