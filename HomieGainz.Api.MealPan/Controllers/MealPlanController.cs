using HomieGainz.Api.MealPan.Interfaces;
using HomieGainz.ApplicationDb.Db.MealDb;
using Microsoft.AspNetCore.Mvc;

namespace HomieGainz.Api.MealPan.Controllers
{
    [ApiController]
    [Route("MealPlans")]
    public class MealPlanController : ControllerBase
    {
        private readonly IMealPlanService mealPlanService;

        public MealPlanController(IMealPlanService mealPlanService)
        {
            this.mealPlanService = mealPlanService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMealsAsync()
        {
            var result = await mealPlanService.GetMealPlansAsync();
            if (result.IsSuccess)
            {
                return Ok(result.MealPlans);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkoutByIdAsync(int id)
        {
            var result = await mealPlanService.GetMealPlanByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.MealPlan);
            }
            return NotFound();
        }

        [HttpGet("ByName/{name}")]
        public async Task<IActionResult> GetWorkoutByNameAsync(string name)
        {
            var result = await mealPlanService.GetMealPlanByNameAsync(name);
            if (result.IsSuccess)
            {
                return Ok(result.MealPlan);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkoutAsync(MealPlan newMealPlan)
        {
            var result = await mealPlanService.CreateMealPlanAsync(newMealPlan);
            if (result.IsSuccess)
            {
                return Ok(result.MealPlan);
            }
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWorkoutAsync(MealPlan updatedMealPlan)
        {
            var result = await mealPlanService.UpdateMealPlanAsync(updatedMealPlan);
            if (result.IsSuccess)
            {
                return Ok(result.MealPlan);
            }
            return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWorkoutAsync(int id)
        {
            var result = await mealPlanService.DeleteMealPlanAsync(id);
            if (result.IsSuccess)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
