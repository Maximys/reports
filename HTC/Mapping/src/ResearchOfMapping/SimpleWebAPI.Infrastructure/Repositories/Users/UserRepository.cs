using AutoFixture;
using SimpleWebAPI.Domain.Users;

namespace SimpleWebAPI.Infrastructure.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        protected const int UserCount = 1000;

        protected Fixture MyFixture { get; }

        public UserRepository()
        {
            MyFixture = new Fixture();
        }

        public async Task<IReadOnlyCollection<User>> GetUsersAsync(CancellationToken cancellationToken)
        {
            IReadOnlyCollection<User> returnValue;

            await Task.Yield();

            cancellationToken.ThrowIfCancellationRequested();

            returnValue = MyFixture.CreateMany<User>(UserCount)
                .ToList();

            return returnValue;
        }
    }
}