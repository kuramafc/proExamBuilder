using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pro.Exam.Builder.Domain.Dtos;
using Pro.Exam.Builder.Domain.Interfaces.Services;

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

        // GET api/v1/Users
        /// <summary>
        /// Test the Api.
        /// </summary>
        [HttpGet("Test")]
        [ProducesResponseType(200)]
        public ActionResult<string> Test()
        {
            return "Service working";
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
        public async Task<StatusCodeResult> Register([FromBody] UserDto user)
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
        public async Task<StatusCodeResult> Login([FromBody] UserDto user)
        {
            var result = await _usersService.Login(user);

            if (result)
            {
                return StatusCode(201);
            }

            return StatusCode(401);
        }

        // GET api/v1/Users
        /// <summary>
        /// Returns a list of 'Disciplinas'.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetSubjects()
        {
            var result = await _usersService.GetUsers();

            return Ok(result);
        }
    }
}
