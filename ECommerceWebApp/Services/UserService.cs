using ECommerceWebApp.Controllers.Request;
using ECommerceWebApp.Data;
using ECommerceWebApp.Models;

namespace ECommerceWebApp.Services
{
    public class UserService(ApplicationDbContext context) : IUserService
    {
        private readonly ApplicationDbContext _context = context;

        public User? GetById(Guid id)
        {
            return _context.UsersList.FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetAll()
        {
            return [.. _context.UsersList];
        }

        public User Add(User user)
        {
            _context.UsersList.Add(user);
            return user;
        }

        public void Update(Guid id, UpdateUserRequestDTO request)
        {
            User? userFound = GetById(id) ?? throw new ArgumentException($"Cannot find user with following Id:'{id}'");
            userFound.Id = request.Id;
            userFound.Name = request.Name;
            userFound.Email = request.Email;
            userFound.DocumentId = request.DocumentId;
            userFound.Birthdate = request.Birthdate;
            userFound.Password = request.Password;
            userFound.IsDeleted = request.IsDeleted;
        }

        public void Delete(Guid id)
        {
            User? user = GetById(id) ?? throw new ArgumentException($"Cannot find user with following Id: '{id}'");
            _context.UsersList.Remove(user);
        }
    }
}