using FilmsApi.Application.Dtos;
using FilmsApi.Core.Entities;

namespace FilmsApi.Application.InterFaces
{
    public interface IUserService
    {
        UserDto CreateUser(CreateOrUpdateUserDto newUser);

        UserDto UpdateUser(int id,CreateOrUpdateUserDto newUser);

        string GenerateToken(User user);

        string UserAuth(AuthDto authDto);

        UserDto GetUserById(int id);
        void DeleteUser(int id);
    }
}
