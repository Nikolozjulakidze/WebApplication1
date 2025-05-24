using FilmsApi.Core.Entities;

namespace FilmsApi.Application.Dtos
{
    public class UserDto
    {
        public UserDto(User user)
        {
            Id = user.Id;
            Name = user.Name;
            LastName = user.LastName;
            Email = user.Email;
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
