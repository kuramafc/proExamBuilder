using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pro.Exam.Builder.Domain.Dtos;
using Pro.Exam.Builder.Domain.Interfaces.Services;
using Pro.Exam.Builder.Domain.Models;

namespace Pro.Exam.Builder.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        // POST api/v1/Users/Register
        /// <summary>
        /// Register a new user.
        /// </summary>
        /// <param name="user"></param>
        /// <response code="201">Registered with success</response>
        /// <response code="400">Bad request</response>  
        [HttpPost("Register")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<StatusCodeResult> Register([FromBody] RegisterUserDto user)
        {
            var result = await _usersService.Register(user);

            if (result)
            {
                return StatusCode(201);
            }

            return StatusCode(400);
        }

        // POST api/v1/Users/Login
        /// <summary>
        /// Verify user and give access.
        /// </summary>
        /// <param name="user"></param>
        /// <response code="201">Login with success</response>
        /// <response code="401">Not Allowed</response>  
        [HttpPost("Login")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<UserResponse>> Login([FromBody] UserDto user)
        {
            var result = await _usersService.Login(user);

            if (result != null)
            {
                return Ok(result);
            }

            return Forbid();
        }

        // GET api/v1/Users
        /// <summary>
        /// Returns a list of 'Disciplinas'.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetUsers()
        {
            var result = await _usersService.GetUsers();

            return Ok(result);
        }

        // Delete api/v1/Users
        /// <summary>
        /// Returns a list of 'Disciplinas'.
        /// </summary>
        [HttpDelete]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> DeleteUsers(string code)
        {
            if (code == null || code == "")
            {
                return BadRequest();
            }

            var result = await _usersService.DeleteUser(code);

            if (result)
            {
                return Ok(code + " Was deleted");
            }
            return StatusCode(500);
        }
    }
}
