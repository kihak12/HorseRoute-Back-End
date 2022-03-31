using HorseRoute.Exceptions;
using HorseRoute.Models.Users;
using HorseRoute.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HorseRoute.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet()]
        [HttpHead]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            try
            {
                return Ok(await _userService.GetUsers());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{userId}", Name = "getUser")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUser(Guid userId)
        {
            try
            {
                return Ok(await _userService.GetUser(userId));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("create", Name = "CreateUser")]
        public ActionResult<UserDto> CreateUser(UserForCreationDto user)
        {
            try
            {
                var userToReturn = _userService.CreateUser(user);
                return CreatedAtRoute("GetUser",
                    new { UserId = userToReturn.UserId },
                    userToReturn);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("{userId}/delete")]
        public async Task<ActionResult> DisableUser(Guid userId)
        {
            try
            {
                await _userService.DisableUser(userId);
                return NoContent();
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
