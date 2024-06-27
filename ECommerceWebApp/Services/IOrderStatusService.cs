using ECommerceWebApp.Controllers.Request;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Services
{
    public interface IOrderStatusService
    {
        OrderStatus? GetById(Guid id);
        List<OrderStatus> GetAll();
        OrderStatus Add(OrderStatus orderDetail);
        void Update(Guid id, UpdateOrderStatusRequestDTO request);
        void Delete(Guid id);
    }
}
