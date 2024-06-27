using ECommerceWebApp.Controllers.Request;
using ECommerceWebApp.Data;
using ECommerceWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWebApp.Services
{
    public class OrderService(ApplicationDbContext context) : IOrderService
    {
        private readonly ApplicationDbContext _context = context;

        public Order? GetById(Guid id)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == id);
        }

        public List<Order> GetAll()
        {
            return [.. _context.Orders.Where(o => !o.IsDeleted)];
        }

        public Order Add(Order order)
        {
            _context.Orders.Add(order);
            return order;
        }

        public void Update(Guid id, UpdateOrderRequestDTO request)
        {
            Order? orderFound = GetById(id) ?? throw new ArgumentException($"Cannot find order with following Id: '{id}'");
            orderFound.Id = request.Id;
            orderFound.OrderId = request.OrderId;
            orderFound.CreateDate = request.CreateDate;
            orderFound.OrderStatusId = request.OrderStatusId;
            orderFound.IsDeleted = request.IsDeleted;

        }

        public void Delete(Guid id)
        {
            Order? orders = GetById(id) ?? throw new ArgumentException($"Cannot find order with following Id: '{id}'");
            orders.IsDeleted = true;
            _context.Orders.Remove(orders);
        }
    }
}
