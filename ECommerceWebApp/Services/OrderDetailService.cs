using ECommerceWebApp.Controllers.Request;
using ECommerceWebApp.Data;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Services
{
    public class OrderDetailService(ApplicationDbContext context) : IOrderDetailService
    {
        private readonly ApplicationDbContext _context = context;

        public OrderDetail? GetById(Guid id)
        {
            return _context.OrderDetails.FirstOrDefault(o => o.Id == id);
        }

        public List<OrderDetail> GetAll()
        {
            return [.. _context.OrderDetails];
        }

        public OrderDetail Add(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            return orderDetail;
        }

        public void Update(Guid id, UpdateOrderDetailRequestDTO request)
        {
            OrderDetail? orderDetailFound = GetById(id) ?? throw new ArgumentException($"Cannot find order detail with following Id:'{id}'");
            orderDetailFound.Id = request.Id;
            orderDetailFound.OrderId = request.OrderId;
            orderDetailFound.ProductId = request.ProductId;
            orderDetailFound.Quantity = request.Quantity;
            orderDetailFound.UnitPrice = request.UnitPrice;
        }

        public void Delete(Guid id)
        {
            OrderDetail? orderDetails = GetById(id) ?? throw new ArgumentException($"Cannot find order detail with following Id: '{id}'");
            _context.OrderDetails.Remove(orderDetails);
        }
    }
}

