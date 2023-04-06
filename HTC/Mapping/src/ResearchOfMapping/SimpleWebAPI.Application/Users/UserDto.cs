using SimpleWebAPI.Domain.Users;

namespace SimpleWebAPI.Application.Users
{
    public class UserDto
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateOnly ModifiedAt { get; }

        public UserDto(int id, string firstName, string lastName, DateOnly modifiedAt)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            ModifiedAt = modifiedAt;
        }

        public static implicit operator UserDto(User user)
        {
            return new UserDto(
                user.Id,
                user.FirstName,
                user.LastName,
                DateOnly.FromDateTime(user.ModifiedAt));
        }
    }
}