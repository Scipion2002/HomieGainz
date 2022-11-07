using HomieGainz.Api.Exercises.Interfaces;
using HomieGainz.ApplicationDb.Db.WorkoutDb;
using Microsoft.AspNetCore.Mvc;

namespace HomieGainz.Api.Exercises.Controllers
{
    [ApiController]
    [Route("/Exercises/")]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseService exerciseService;

        public ExercisesController(IExerciseService exerciseService)
        {
            this.exerciseService = exerciseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetExercisesAsync()
        {
            var result = await exerciseService.GetExercisesAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Exercises);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExerciseByIdAsync(int id)
        {
            var result = await exerciseService.GetExerciseByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Exercise);
            }
            return NotFound();
        }

        [HttpGet("ByName/{name}")]
        public async Task<IActionResult> GetExerciseByNameAsync(string name)
        {
            var result = await exerciseService.GetExerciseByNameAsync(name);
            if (result.IsSuccess)
            {
                return Ok(result.Exercise);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateExerciseAsync(Exercise newExercise)
        {
            var result = await exerciseService.CreateExerciseAsync(newExercise);
            if (result.IsSuccess)
            {
                return Ok(result.Exercise);
            }
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateExerciseAsync(Exercise updatedExercise)
        {
            var result = await exerciseService.UpdateExerciseAsync(updatedExercise);
            if (result.IsSuccess)
            {
                return Ok(result.Exercise);
            }
            return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteExerciseAsync(int id)
        {
            var result = await exerciseService.DeleteExerciseAsync(id);
            if (result.IsSuccess)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
