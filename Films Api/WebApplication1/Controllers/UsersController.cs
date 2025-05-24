using FilmsApi.Application.Dtos;
using FilmsApi.Application.InterFaces;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<string> AuthUser([FromBody] AuthDto authDto)
        {
           
            return Ok();
        }

    }
}
