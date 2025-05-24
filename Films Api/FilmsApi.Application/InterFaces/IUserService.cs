using FilmsApi.Application.Dtos;
using FilmsApi.Core.Entities;

namespace FilmsApi.Application.InterFaces
{
    public interface IUserService
    {
        UserDto CreateUser(CreateOrUpdateUserDto newUser);

        string AuthUser(AuthDto authDto);

        string GenerateToken(User user);
    }
}
