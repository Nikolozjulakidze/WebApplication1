using FilmsApi.Application.Dtos;
using FilmsApi.Application.InterFaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController:ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<UserDto> AddUser([FromBody]CreateOrUpdateUserDto createUser)
        {
            var newUser = _userService.CreateUser(createUser);

            return Ok(newUser);
        }

        [HttpPost("auth")]
        public ActionResult<string> Auth([FromBody] AuthDto authDto)
        {
            var token = _userService.UserAuth(authDto);

            return Ok(token);
        }

        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<UserDto> UpdateUser(int id,[FromBody] CreateOrUpdateUserDto createUser)
        {
            var claim = User.Claims.
                FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            
            
             int.TryParse(claim.Value,out int userId);

            if(userId != id)
            {
                return Unauthorized();
            }

            var newUser = _userService.UpdateUser(id,createUser);

            return Ok(newUser);
        }

        [Authorize]
        [HttpGet("{id}")]

        public ActionResult<UserDto> GetUserById(int id)
        {
            var claim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            int.TryParse(claim?.Value, out int userId);

            if (userId != id)
            {
                return Unauthorized();
            }

            var user = _userService.GetUserById(id);
            return Ok(user);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult<UserDto> DeleteUser(int id)
        {
            var claim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            int.TryParse(claim?.Value, out int userId);

            if (userId != id)
            {
                return Unauthorized();
            }

            _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
