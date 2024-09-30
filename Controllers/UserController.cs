using Microsoft.AspNetCore.Mvc;
using Shop.User.API.Abstractions;
using Shop.User.API.Contracts;
using Shop.User.API.CustomExceptions;

namespace Shop.User.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> UpdateUserAsync(Guid id, [FromBody] UpdateUsersRequest updateUsersRequest)
        {
            try
            {
                var userId = await _userService.UpdateUserAsync(id, updateUsersRequest.UserName, updateUsersRequest.Telephone);
                return Ok(userId);
            }
            catch (ValidatorException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UpdateUserException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
