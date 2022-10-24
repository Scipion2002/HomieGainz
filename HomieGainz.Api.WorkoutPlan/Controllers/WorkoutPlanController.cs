using HomieGainz.Api.WorkoutPlans.Interfaces;
using HomieGainz.ApplicationDb.Db.WorkoutDb;
using Microsoft.AspNetCore.Mvc;

namespace HomieGainz.Api.WorkoutPlans.Controllers
{
    [ApiController]
    [Route("/WorkoutPlans")]
    public class WorkoutPlanController : ControllerBase
    {
        private readonly IWorkoutPlanService workoutPlanService;

        public WorkoutPlanController(IWorkoutPlanService workoutPlanService)
        {
            this.workoutPlanService = workoutPlanService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWorkoutsPlanAsync()
        {
            var result = await workoutPlanService.GetWorkoutPlansAsync();
            if (result.IsSuccess)
            {
                return Ok(result.WorkoutPlans);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkoutPlanByIdAsync(int id)
        {
            var result = await workoutPlanService.GetWorkoutPlanByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.WorkoutPlan);
            }
            return NotFound();
        }

        [HttpGet("ByName/{name}")]
        public async Task<IActionResult> GetWorkoutPlanByNameAsync(string name)
        {
            var result = await workoutPlanService.GetWorkoutPlanByNameAsync(name);
            if (result.IsSuccess)
            {
                return Ok(result.WorkoutPlan);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkoutPlanAsync(WorkoutPlan newWorkoutPlan)
        {
            var result = await workoutPlanService.CreateWorkoutPlanAsync(newWorkoutPlan);
            if (result.IsSuccess)
            {
                return Ok(result.WorkoutPlan);
            }
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWorkoutAsync(WorkoutPlan updatedWorkoutPlan)
        {
            var result = await workoutPlanService.UpdateWorkoutPlanAsync(updatedWorkoutPlan);
            if (result.IsSuccess)
            {
                return Ok(result.WorkoutPlan);
            }
            return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWorkoutPlanAsync(int id)
        {
            var result = await workoutPlanService.DeleteWorkoutPlanAsync(id);
            if (result.IsSuccess)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
