using ECommerceWebApp.Controllers.Request;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Services
{
    public interface IOrderService
    {
        Order? GetById(Guid id);
        List<Order> GetAll();
        Order Add(Order order);
        void Update(Guid id, UpdateOrderRequestDTO request);
        void Delete(Guid id);
    }
}
