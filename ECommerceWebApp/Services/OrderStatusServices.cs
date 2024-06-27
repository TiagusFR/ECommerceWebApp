using ECommerceWebApp.Controllers.Request;
using ECommerceWebApp.Data;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Services
{
    public class OrderStatusServices(ApplicationDbContext context) : IOrderStatusService
    {
        private readonly ApplicationDbContext _context = context;

        public OrderStatus? GetById(Guid id)
        {
            return _context.OrderStatuses.FirstOrDefault(o => o.Id == id);
        }

        public List<OrderStatus> GetAll()
        {
            return [.. _context.OrderStatuses];
        }

        public OrderStatus Add(OrderStatus orderStatus)
        {
            _context.OrderStatuses.Add(orderStatus);
            return orderStatus;
        }

        public void Update(Guid id, UpdateOrderStatusRequestDTO request)
        {
            OrderStatus? orderStatusFound = GetById(id) ?? throw new ArgumentException($"Cannot find order status with following Id:'{id}'");
            orderStatusFound.Id = request.Id;
            orderStatusFound.StatusId = request.StatusId;
            orderStatusFound.StatusName = request.StatusName;
        }

        public void Delete(Guid id)
        {
            OrderStatus? orderStatus = GetById(id) ?? throw new ArgumentException($"Cannot find order status with following Id: '{id}'");
            _context.OrderStatuses.Remove(orderStatus);
        }
    }
}
