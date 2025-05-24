using FilmsApi.Application.Dtos;
using FilmsApi.Application.InterFaces;
using FilmsApi.Core;
using FilmsApi.Core.Entities;
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

        public string AuthUser(AuthDto authRequest)
        {
           var user = _repository.GetUserByEmailAndPassword(authRequest.Email, authRequest.Password);

            if(user == null)
            {
                throw new Exception("User not found");
            }

             return GenerateToken(user);

            
        }

        public UserDto CreateUser(CreateOrUpdateUserDto newUser)
        {
            var userToCreate = new User()
            {
                Name = newUser.Name,
                LastName = newUser.LastName,
                Email = newUser.Email,
                Password = newUser.Password
            };

            var createdUser = _repository.AddUser(userToCreate);
            return new UserDto(createdUser);
        }

        public string GenerateToken(User user)
        {
            var key = _configuration["Jwt:Key"]!;
            var issuer = _configuration["Jwt:Issuer"]!;
            var audience = _configuration["Jwt:Audience"]!;

            var claims = new[]
            {
              new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
              new Claim(JwtRegisteredClaimNames.Email,user.Email),
              new Claim(ClaimTypes.Role, DbConsts.Roles.Member)
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
    }
}
