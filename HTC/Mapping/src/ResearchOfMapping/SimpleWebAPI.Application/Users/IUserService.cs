namespace SimpleWebAPI.Application.Users
{
    public interface IUserService
    {
        Task<IReadOnlyCollection<UserDto>> GetUsersWithAutoMapperAsync(CancellationToken cancellationToken);

        Task<IReadOnlyCollection<UserDto>> GetUsersWithManualMappingAsync(CancellationToken cancellationToken);

        Task<IReadOnlyCollection<UserDto>> GetUsersWithMappingByHelperAsync(CancellationToken cancellationToken);

        Task<IReadOnlyCollection<UserDto>> GetUsersWithMappingByImplicitOperatorAsync(CancellationToken cancellationToken);
    }
}
