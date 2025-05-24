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

        public User? GetUserByEmailAndPassword(string email, string password)
        {
           var existingUser = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
 
            return existingUser;
        }
    }
}
