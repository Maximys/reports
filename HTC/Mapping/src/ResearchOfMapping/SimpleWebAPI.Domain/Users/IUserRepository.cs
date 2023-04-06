namespace SimpleWebAPI.Domain.Users
{
    public interface IUserRepository
    {
        Task<IReadOnlyCollection<User>> GetUsersAsync(CancellationToken cancellationToken);
    }
}
