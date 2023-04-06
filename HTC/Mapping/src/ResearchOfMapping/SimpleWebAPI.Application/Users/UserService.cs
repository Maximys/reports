using AutoMapper;
using SimpleWebAPI.Domain.Users;

namespace SimpleWebAPI.Application.Users
{
    public class UserService : IUserService
    {
        protected IMapper Mapper { get; }

        protected IUserRepository UserRepository { get; }

        public UserService(
            IMapper mapper,
            IUserRepository userRepository)
        {
            Mapper = mapper;
            UserRepository = userRepository;
        }

        public async Task<IReadOnlyCollection<UserDto>> GetUsersWithAutoMapperAsync(CancellationToken cancellationToken)
        {
            IEnumerable<User> rawUsers;
            IReadOnlyCollection<UserDto> returnValue;

            rawUsers = await UserRepository.GetUsersAsync(cancellationToken);
            returnValue = Mapper.Map<IReadOnlyCollection<UserDto>>(rawUsers);

            return returnValue;
        }

        public async Task<IReadOnlyCollection<UserDto>> GetUsersWithManualMappingAsync(CancellationToken cancellationToken)
        {
            IEnumerable<User> rawUsers;
            IReadOnlyCollection<UserDto> returnValue;

            rawUsers = await UserRepository.GetUsersAsync(cancellationToken);
            returnValue = rawUsers
                .Select(u => new UserDto(
                    u.Id,
                    u.FirstName,
                    u.LastName,
                    DateOnly.FromDateTime(u.ModifiedAt)))
                .ToList();

            return returnValue;
        }

        public async Task<IReadOnlyCollection<UserDto>> GetUsersWithMappingByHelperAsync(CancellationToken cancellationToken)
        {
            IEnumerable<User> rawUsers;
            IReadOnlyCollection<UserDto> returnValue;

            rawUsers = await UserRepository.GetUsersAsync(cancellationToken);
            returnValue = rawUsers
                .Select(u => UserMappingHelper.MapToUserDto(u))
                .ToList();

            return returnValue;
        }

        public async Task<IReadOnlyCollection<UserDto>> GetUsersWithMappingByImplicitOperatorAsync(CancellationToken cancellationToken)
        {
            IEnumerable<User> rawUsers;
            IReadOnlyCollection<UserDto> returnValue;

            rawUsers = await UserRepository.GetUsersAsync(cancellationToken);
            returnValue = rawUsers
                .Select(u => (UserDto)u)
                .ToList();

            return returnValue;
        }
    }
}
