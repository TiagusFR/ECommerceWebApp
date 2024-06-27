using ECommerceWebApp.Controllers.Request;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Services
{
    public interface ICartService
    {
        Cart? GetById(Guid id);
        List<Cart> GetAll();
        Cart Add(Cart cart);
        void Update(Guid id, UpdateCartRequestDTO request);
        void Delete(Guid id);
    }
}
