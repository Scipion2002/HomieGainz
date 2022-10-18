using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using HomieGainz.Api.Application.Interfaces;
using HomieGainz.ApplicationDb.Db.UserDb;
using HomieGainz.UserMeals.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HomieGainz.Api.Application.Controllers
{
    [ApiController]
    [Route("/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            var result = await userService.GetUsersAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Users);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var result = await userService.GetUserByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.User);
            }
            return NotFound();
        }

        [HttpPost("GetUser")]
        public async Task<IActionResult> GetUserAsync([FromBody] JsonObject jsonBody)
        {
            var result = await userService.GetUserAsync(jsonBody["Username"].ToString(), jsonBody["Password"].ToString());
            if (result.IsSuccess)
            {
                return Ok(result.User);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] User user)
        {
            var result = await userService.CreateUserAsync(user);
            if (result.IsSuccess)
            {
                return Ok(result.User);
            }
            return NoContent();

        }
        
    }
}
