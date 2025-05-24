using FilmsApi.Core.Entities;

namespace FilmsApi.Application.InterFaces
{
    public interface IUserRepository
    {
        User AddUser(User user);
        User? GetUserByEmailAndPassword(string email,string password);
    }
}
