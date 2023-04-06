using AutoMapper;
using SimpleWebAPI.Domain.Users;

namespace SimpleWebAPI.Application.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<DateTime, DateOnly>()
                .ConstructUsing(src => new DateOnly(src.Year, src.Month, src.Day));

            CreateMap<User, UserDto>()
                .ForCtorParam("id", m => m.MapFrom(u => u.Id))
                .ForCtorParam("firstName", m => m.MapFrom(u => u.FirstName))
                .ForCtorParam("lastName", m => m.MapFrom(u => u.LastName))
                .ForCtorParam("modifiedAt", m => m.MapFrom(u => u.ModifiedAt));
        }
    }
}
