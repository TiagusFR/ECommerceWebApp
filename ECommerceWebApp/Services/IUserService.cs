using ECommerceWebApp.Controllers.Request;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Services
{
    public interface IUserService
    {
        User? GetById(Guid id);
        List<User> GetAll();
        User Add(User user);
        void Update(Guid id, UpdateUserRequestDTO request);
        void Delete(Guid id);
        Task<User?> AuthenticateAsync(string username, string password);
        Task<User> RegisterAsync(RegisterDto registerDto);
    }
}
