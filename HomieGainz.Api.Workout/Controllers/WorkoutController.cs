using HomieGainz.Api.Workouts.Interfaces;
using HomieGainz.ApplicationDb.Db.WorkoutDb;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace HomieGainz.Api.Workouts.Controllers
{
    [ApiController]
    [Route("/Workouts")]
    public class WorkoutController : ControllerBase
    {
        private readonly IWorkoutService workoutService;

        public WorkoutController(IWorkoutService workoutService)
        {
            this.workoutService = workoutService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            var result = await workoutService.GetWorkoutsAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Workouts);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkoutByIdAsync(int id)
        {
            var result = await workoutService.GetWorkoutByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Workout);
            }
            return NotFound();
        }

        [HttpGet("ByName/{name}")]
        public async Task<IActionResult> GetWorkoutByNameAsync(string name)
        {
            var result = await workoutService.GetWorkoutByNameAsync(name);
            if (result.IsSuccess)
            {
                return Ok(result.Workout);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkoutAsync(Workout newWorkout)
        {
            var result = await workoutService.CreateWorkoutAsync(newWorkout);
            if (result.IsSuccess)
            {
                return Ok(result.Workout);
            }
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWorkoutAsync(Workout updatedWorkout)
        {
            var result = await workoutService.UpdateWorkoutAsync(updatedWorkout);
            if (result.IsSuccess)
            {
                return Ok(result.Workout);
            }
            return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWorkoutAsync(int id)
        {
            var result = await workoutService.DeleteWorkoutAsync(id);
            if (result.IsSuccess)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
