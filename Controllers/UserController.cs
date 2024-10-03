using Microsoft.AspNetCore.Mvc;
using Shop.User.API.Abstractions;
using Shop.User.API.Contracts;
using Shop.User.API.CustomExceptions;
using Shop.User.API.Models;
using Shop.User.API.Repositories;

namespace Shop.User.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateUserAsync(UserRequest userRequest)
        {
            try
            {
                var userId = await _userService.CreateUserAsync(userRequest.Id, userRequest.UserName, userRequest.Email,
                    userRequest.Telephone, userRequest.Password, userRequest.Role);

                return Ok(userRequest.Id);
            }
            catch (ValidatorException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (UserException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAllUsersAsync()
        {
            try
            {
                return await _userService.GetAllUsersAsync();
            }
            catch (UserException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
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
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (UserException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
