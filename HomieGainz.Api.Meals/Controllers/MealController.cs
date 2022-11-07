using HomieGainz.Api.Meals.Interfaces;
using HomieGainz.ApplicationDb.Db.MealDb;
using HomieGainz.ApplicationDb.Db.WorkoutDb;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HomieGainz.Api.Meals.Controllers
{
    [ApiController]
    [Route("/Meals/")]
    public class MealController : ControllerBase
    {
        private readonly IMealService mealService;

        public MealController(IMealService mealService)
        {
            this.mealService = mealService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMealsAsync()
        {
            var result = await mealService.GetMealsAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Meals);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkoutByIdAsync(int id)
        {
            var result = await mealService.GetMealByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Meal);
            }
            return NotFound();
        }

        [HttpGet("ByName/{name}")]
        public async Task<IActionResult> GetWorkoutByNameAsync(string name)
        {
            var result = await mealService.GetMealByNameAsync(name);
            if (result.IsSuccess)
            {
                return Ok(result.Meal);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkoutAsync(Meal newMeal)
        {
            var result = await mealService.CreateMealAsync(newMeal);
            if (result.IsSuccess)
            {
                return Ok(result.Meal);
            }
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWorkoutAsync(Meal updatedMeal)
        {
            var result = await mealService.UpdateMealAsync(updatedMeal);
            if (result.IsSuccess)
            {
                return Ok(result.Meal);
            }
            return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWorkoutAsync(int id)
        {
            var result = await mealService.DeleteMealAsync(id);
            if (result.IsSuccess)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
