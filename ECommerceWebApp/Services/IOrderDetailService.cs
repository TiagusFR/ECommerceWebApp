using ECommerceWebApp.Controllers.Request;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Services
{
    public interface IOrderDetailService
    {
        OrderDetail? GetById(Guid id);
        List<OrderDetail> GetAll();
        OrderDetail Add(OrderDetail orderDetail);
        void Update(Guid id, UpdateOrderDetailRequestDTO request);
        void Delete(Guid id);
    }
}
