using ECommerceWebApp.Controllers.Request;
using ECommerceWebApp.Data;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Services
{
    public class CartDetailService(ApplicationDbContext context) : ICartDetailService
    {
        private readonly ApplicationDbContext _context = context;

        public CartDetail? GetById(Guid id)
        {
            return _context.CartDetails.FirstOrDefault(c => c.Id == id);
        }

        public List<CartDetail> GetAll()
        {
            return [.. _context.CartDetails.Where(c => !c.IsDeleted)];
        }

        public CartDetail Add(CartDetail cartDetails)
        {
            _context.CartDetails.Add(cartDetails);
            return cartDetails;
        }

        public void Update(Guid id, UpdateCartDetailRequestDTO request)
        {
            CartDetail? cartDetailFound = GetById(id) ?? throw new ArgumentException($"Cannot find cart detail with following Id: '{id}'");
            cartDetailFound.Id = request.Id;
            cartDetailFound.ShoppingCartId = request.ShoppingCartId;
            cartDetailFound.ProductId = request.ProductId; 
            cartDetailFound.Quantity = request.Quantity;
            cartDetailFound.IsDeleted = request.IsDeleted;
        }

        public void Delete(Guid id)
        {
            CartDetail? cartDetails = GetById(id) ?? throw new ArgumentException($"Cannot find cart detail with following Id: '{id}'");
            cartDetails.IsDeleted = true;
            _context.CartDetails.Remove(cartDetails);
        }
    }
}
