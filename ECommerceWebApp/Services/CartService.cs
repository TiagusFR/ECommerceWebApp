using ECommerceWebApp.Controllers.Request;
using ECommerceWebApp.Data;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Services
{
    public class CartService(ApplicationDbContext context) : ICartService
    {
        private readonly ApplicationDbContext _context = context;

        public Cart? GetById(Guid id) 
        {
            return _context.Carts.FirstOrDefault(c => c.Id == id);
        }

        public List<Cart>GetAll()
        {
            return [.. _context.Carts.Where(c => !c.IsDeleted)];
        }

        public Cart Add(Cart cart) 
        {
            _context.Carts.Add(cart);
            return cart;
        }

        public void Update (Guid id, UpdateCartRequestDTO request) 
        {
            Cart? cartFound = GetById(id) ?? throw new ArgumentException($"Cannot find cart with following Id: '{id}'");
            cartFound.Id = request.Id;
            cartFound.CartId = request.CartId;
            cartFound.IsDeleted = request.IsDeleted;
        }

        public void Delete(Guid id) 
        {
            Cart? cart = GetById(id) ?? throw new ArgumentException($"Cannot find cart with following Id: '{id}'");
            cart.IsDeleted = true;
            _context.Carts.Remove(cart);
        }
    }
}
