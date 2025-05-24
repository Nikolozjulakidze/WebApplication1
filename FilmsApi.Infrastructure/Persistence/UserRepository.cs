using FilmsApi.Application.Dtos;
using FilmsApi.Application.InterFaces;
using FilmsApi.Core.Entities;
using WebApplication1.Persistence;

namespace FilmsApi.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User AddUser(User user)
        {
           _context.Users.Add(user);

            _context.SaveChanges();

            return user;
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public User? GetUserByEmailAndPassword(string email, string password)
        {
           var existingUser = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
 
            return existingUser;
        }

        public User? GetUserById(int id)
        {
           return _context.Users
                .FirstOrDefault(u => u.Id == id);
        }

        public User UpdateUser(CreateOrUpdateUserDto updateUser, User user)
        {
            user.Email = updateUser.Email;
            user.Password = updateUser.Password;
            user.Name = updateUser.Name;
            user.LastName = updateUser.LastName;
            user.Role = updateUser.Role;

            _context.SaveChanges();

            return user;
        }
    }
}
