using ECommerceWebApp.Controllers.Request;
using ECommerceWebApp.Data;
using ECommerceWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWebApp.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public User? GetById(Guid id)
        {
            return _context.UsersList.FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetAll()
        {
            return _context.UsersList.ToList();
        }

        public User Add(User user)
        {
            _context.UsersList.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void Update(Guid id, UpdateUserRequestDTO request)
        {
            User? userFound = GetById(id) ?? throw new ArgumentException($"Cannot find user with following Id:'{id}'");
            userFound.Name = request.Name;
            userFound.Email = request.Email;
            userFound.DocumentId = request.DocumentId;
            userFound.Birthdate = request.Birthdate;
            userFound.PasswordHash = request.Password;
            userFound.IsDeleted = request.IsDeleted;
            userFound.Role = request.Role;
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            User? user = GetById(id) ?? throw new ArgumentException($"Cannot find user with following Id: '{id}'");
            _context.UsersList.Remove(user);
            _context.SaveChanges();
        }

        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            var user = await _context.UsersList.SingleOrDefaultAsync(u => u.Email == username && u.PasswordHash == password);
            return user;
        }

        public async Task<User> RegisterAsync(RegisterDto registerDto)
        {
            var user = new User
            {
                Email = registerDto.Email,
                PasswordHash = registerDto.Password,
                Role = "User"
            };

            _context.UsersList.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
