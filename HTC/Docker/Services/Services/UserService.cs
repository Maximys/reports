using Data.Database;
using Data.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services
{
    public class UserService
    {
        protected ApplicationContext _dbContext { get; }

        public UserService(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        //ВНИМАНИЕ: возвращать сущность базы данных из сервиса - это антипаттерн. Сделал так лишь для демонстрации чтобы не усложнять код.
        public async Task<IEnumerable<User>> GetUsers()
        {
            IEnumerable<User> returnValue;

            returnValue = await _dbContext.Users.ToListAsync();

            return returnValue;
        }

        public async Task AddUser(User userForAdd)
        {
            await _dbContext.Users.AddAsync(userForAdd);
            await _dbContext.SaveChangesAsync();
        }
    }
}
