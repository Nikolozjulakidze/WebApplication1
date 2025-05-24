using FilmsApi.Application.Dtos;
using FilmsApi.Core.Entities;

namespace FilmsApi.Application.InterFaces
{
    public interface IUserRepository
    {
        User AddUser(User user);

        User? GetUserById(int id);

        User? GetUserByEmailAndPassword(string email,string password);

        User UpdateUser(CreateOrUpdateUserDto updateUser,User user);

        void DeleteUser(User user);
    }
}
