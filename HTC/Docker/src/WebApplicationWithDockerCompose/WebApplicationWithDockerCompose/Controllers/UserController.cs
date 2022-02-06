using Data.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplicationWithDockerCompose.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        protected UserService _userService { get; }

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userService.GetUsers();
        }

        [HttpPost]
        public async Task AddUser(User userForAdd)
        {
            await _userService.AddUser(userForAdd);
        }
    }
}
