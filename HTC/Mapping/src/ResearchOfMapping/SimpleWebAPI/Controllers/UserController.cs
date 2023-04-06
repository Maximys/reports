using Microsoft.AspNetCore.Mvc;
using SimpleWebAPI.Application.Users;

namespace SimpleWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        protected IUserService UserService { get; }

        public UserController(IUserService userService)
        {
            UserService = userService;
        }

        [HttpGet("GetUsersWithAutoMapper")]
        public async Task<IEnumerable<UserDto>> GetUsersWithAutoMapperAsync(CancellationToken cancellationToken)
        {
            return await UserService.GetUsersWithAutoMapperAsync(cancellationToken);
        }

        [HttpGet("GetUsersWithManual")]
        public async Task<IEnumerable<UserDto>> GetUsersWithManualMappingAsync(CancellationToken cancellationToken)
        {
            return await UserService.GetUsersWithManualMappingAsync(cancellationToken);
        }

        [HttpGet("GetUsersWithMappingByHelper")]
        public async Task<IEnumerable<UserDto>> GetUsersWithMappingByHelperAsync(CancellationToken cancellationToken)
        {
            return await UserService.GetUsersWithMappingByHelperAsync(cancellationToken);
        }

        [HttpGet("GetUsersWithMappingByImplicitOperator")]
        public async Task<IEnumerable<UserDto>> GetUsersWithMappingByImplicitOperatorAsync(CancellationToken cancellationToken)
        {
            return await UserService.GetUsersWithMappingByImplicitOperatorAsync(cancellationToken);
        }
    }
}