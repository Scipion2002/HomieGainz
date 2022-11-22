using HomieGainz.Api.Exercises.Interfaces;
using HomieGainz.ApplicationDb.Db;
using HomieGainz.ApplicationDb.Db.WorkoutDb;
using Microsoft.EntityFrameworkCore;

namespace HomieGainz.Api.Exercises.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ILogger<ExerciseService> logger;

        public ExerciseService(ApplicationDbContext dbContext, ILogger<ExerciseService> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public async Task<(bool IsSuccess, IEnumerable<Exercise>? Exercises, string? ErrorMessage)> GetExercisesAsync()
        {
            try
            {
                logger?.LogInformation("Querying exercises");
                var exercises = await dbContext.Exercises.ToListAsync();
                if (exercises != null && exercises.Any())
                {
                    logger?.LogInformation($"{exercises.Count} exercise(s) found");
                    return (true, exercises, null);
                }
                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
        
        public async Task<(bool IsSuccess, Exercise? Exercise, string? ErrorMessage)> GetExerciseByIdAsync(int id)
        {
            try
            {
                logger?.LogInformation("Querying exercise");
                var exercise = await dbContext.Exercises.FirstOrDefaultAsync(x => x.Id == id);
                if (exercise != null)
                {
                    logger?.LogInformation("exercise found!");
                    return (true, exercise, null);
                }
                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Exercise? Exercise, string? ErrorMessage)> GetExerciseByNameAsync(string name)
        {
            try
            {
                logger?.LogInformation("Querying exercise");
                var exercise = await dbContext.Exercises.FirstOrDefaultAsync(x => x.ExerciseName == name);
                if (exercise != null)
                {
                    logger?.LogInformation("exercise found!");
                    return (true, exercise, null);
                }
                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Exercise? Exercise, string? ErrorMessage)> CreateExerciseAsync(Exercise newExercise)
        {
            try
            {
                logger?.LogInformation("Creating exercise");
                if (newExercise != null)
                {
                    await this.dbContext.AddAsync(newExercise);
                    dbContext.SaveChanges();
                    logger?.LogInformation("exercise created!");
                    return (true, newExercise, null);
                }
                return (false, null, "exercise not created");
            }
            catch (Exception ex)
            {

                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Exercise? Exercise, string? ErrorMessage)> UpdateExerciseAsync(Exercise updatedExercise)
        {
            try
            {
                logger?.LogInformation("Finding exercise");
                var oldExercise = await GetExerciseByIdAsync(updatedExercise.Id);
                if (oldExercise.IsSuccess && oldExercise.Exercise != null)
                {
                    logger?.LogInformation("found exercise, updating now");
                    oldExercise.Exercise.ExerciseName = updatedExercise.ExerciseName;
                    oldExercise.Exercise.TargetMuscle = updatedExercise.TargetMuscle;
                    oldExercise.Exercise.Video = updatedExercise.Video;
                    oldExercise.Exercise.SetAmt = updatedExercise.SetAmt;
                    oldExercise.Exercise.RepAmt = updatedExercise.RepAmt;
                    oldExercise.Exercise.Description = updatedExercise.Description;
                    oldExercise.Exercise.Workouts = updatedExercise.Workouts;
                    dbContext.SaveChanges();
                    logger?.LogInformation("exercise Updated");
                    return (true, updatedExercise, null);
                }
                return (false, null, "exercise not Found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Exercise? Exercise, string? ErrorMessage)> DeleteExerciseAsync(int id)
        {
            try
            {
                logger?.LogInformation("Finding exercise");
                var oldExercise = await GetExerciseByIdAsync(id);
                if (oldExercise.IsSuccess)
                {
                    logger?.LogInformation("found exercise, deleting now");
                    dbContext?.Remove(oldExercise.Exercise);
                    dbContext?.SaveChanges();
                    logger?.LogInformation("exercise deleted");
                    return (true, null, null);
                }
                return (false, null, "exercise not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
