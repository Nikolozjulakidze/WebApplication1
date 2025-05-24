using FilmsApi.Application.Dtos;
using FilmsApi.Application.InterFaces;
using FilmsApi.Core.Entities;
using FilmsApi.Core.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FilmsApi.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository repository,IConfiguration configuration)
        {
          _repository = repository;
          _configuration = configuration;
        }

        public UserDto CreateUser(CreateOrUpdateUserDto newUser)
        {
            var userToCreate = new User()
            {
                Name = newUser.Name,
                LastName = newUser.LastName,
                Email = newUser.Email,
                Password = newUser.Password,
                Role = newUser.Role,
            };

            var createdUser = _repository.AddUser(userToCreate);
            return new UserDto(createdUser);
        }

        public void DeleteUser(int id)
        {
            var user = _repository.GetUserById(id);

            if(user == null)
            {
                throw new NotFoundException(id, nameof(user));
            }

            _repository.DeleteUser(user);
        }

        public string GenerateToken(User user)
        {
            string key = _configuration["Jwt:Key"];
            string issuer = _configuration["Jwt:Issuer"];
            string audience = _configuration["Jwt:Audience"];

            var claims = new[]
            {
              new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
              new Claim(JwtRegisteredClaimNames.Email,user.Email),
              new Claim(ClaimTypes.Role,user.Role.ToString()),
          
        };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
              issuer: issuer,
              audience: audience,
              claims: claims,
              expires: DateTime.UtcNow.AddHours(4),
              signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public UserDto GetUserById(int id)
        {
            var user = _repository.GetUserById(id);

            if(user == null)
            {
                throw new NotFoundException(id,nameof(user));
            }

            return new UserDto(user);
        }

        public UserDto UpdateUser(int id, CreateOrUpdateUserDto updateUser)
        {
            var user = _repository.GetUserById(id);

            if (user == null)
            {
                throw new NotFoundException(id,nameof(user));
            }
            var book = _repository.UpdateUser(updateUser,user);

            return new UserDto(user);
        }

        public string UserAuth(AuthDto authDto)
        {
           var user = _repository.GetUserByEmailAndPassword(authDto.Email, authDto.Password);

            if (user == null)
            {
                throw new NotFoundException(authDto.Email);
            }

            return GenerateToken(user);
        }
    }
}
