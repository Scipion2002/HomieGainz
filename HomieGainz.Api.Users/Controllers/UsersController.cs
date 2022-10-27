using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using HomieGainz.Api.Application.Interfaces;
using HomieGainz.ApplicationDb.Db.UserDb;
using HomieGainz.ApplicationDb.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

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

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var result = await userService.GetUserByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.User);
            }
            return NotFound();
        }

        [HttpGet("/GetUser")]
        public async Task<IActionResult> GetUserAsync(string username)
        {
            var result = await userService.GetUserAsync(username);
            if (result.IsSuccess)
            {
                return Ok(result.User);
            }
            return NotFound();
        }

        [Authorize]
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

        [Authorize]
        [HttpPut()]
        public async Task<IActionResult> UpdateUserAsync([FromBody] User user)
        {
            var result = await userService.UpdateUserAsync(user);
            if (result.IsSuccess)
            {
                return Ok(result.User);
            }
            return NotFound();
        }

        [Authorize]
        [HttpDelete("/{id}")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            var result = await userService.DeleteUserAsync(id);
            if (result.IsSuccess)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPost("/questionaireTotal/{total}")]
        public async Task<IActionResult> AddMealPlanAndWorkoutPlan([FromBody]User user, int total)
        {
            var result = await userService.GetQuestionaireTotalAsync(user, total);
            if(result.IsSuccess)
            {
                return Ok(result.User);
            }
            return NotFound();
        }

        [HttpPost("/changeMealPlan")]
        public async Task<IActionResult> ChangeMealPlan([FromBody]User user, int mealPlanId)
        {
            var result = await userService.ChangeMealPlanAsync(user, mealPlanId);
            if (result.IsSuccess)
            {
                return Ok(result.User);
            }
            return NotFound();
        }

        [HttpPost("/changeWorkoutPlan")]
        public async Task<IActionResult> ChangeWorkoutPlan([FromBody] User user, int workoutPlanId)
        {
            var result = await userService.ChangeWorkoutPlanAsync(user, workoutPlanId);
            if (result.IsSuccess)
            {
                return Ok(result.User);
            }
            return NotFound();
        }
    }
}
