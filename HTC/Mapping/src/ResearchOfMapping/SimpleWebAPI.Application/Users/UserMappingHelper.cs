using SimpleWebAPI.Domain.Users;

namespace SimpleWebAPI.Application.Users
{
    public static class UserMappingHelper
    {
        public static UserDto MapToUserDto(User user)
        {
            return new UserDto(
                user.Id,
                user.FirstName,
                user.LastName,
                DateOnly.FromDateTime(user.ModifiedAt));
        }
    }
}
