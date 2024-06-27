using AutoMapper;
using ECommerceWebApp.Controllers.Request;
using ECommerceWebApp.Models;
using ECommerceWebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebApp.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController(IUserService service, IMapper mapper) : ControllerBase
    {
        private readonly IUserService _service = service;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var user = _service.GetById(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post(UserRequestDTO request)
        {
            var result = _service.Add(_mapper.Map<User>(request));

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, UpdateUserRequestDTO request)
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