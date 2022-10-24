using HomieGainz.Api.Workouts.Interfaces;
using HomieGainz.ApplicationDb.Db.WorkoutDb;
using HomieGainz.ApplicationDb.Db;
using Microsoft.EntityFrameworkCore;

namespace HomieGainz.Api.Workouts.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ILogger<WorkoutService> logger;

        public WorkoutService(ApplicationDbContext dbContext, ILogger<WorkoutService> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            SeedData();
        }

        public async Task<(bool IsSuccess, IEnumerable<Workout>? Workouts, string? ErrorMessage)> GetWorkoutsAsync()
        {
            try
            {
                logger?.LogInformation("Querying workouts");
                var workouts = await dbContext.Workouts.ToListAsync();
                if (workouts != null && workouts.Any())
                {
                    logger?.LogInformation($"{workouts.Count} workout(s) found");
                    return (true, workouts, null);
                }
                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
        public async Task<(bool IsSuccess, Workout? Workout, string? ErrorMessage)> GetWorkoutByIdAsync(int id)
        {
            try
            {
                logger?.LogInformation("Querying workout");
                var workout = await dbContext.Workouts.FirstOrDefaultAsync(x => x.Id == id);
                if(workout != null)
                {
                    logger?.LogInformation("workout found!");
                    return (true, workout, null);
                }
                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Workout? Workout, string? ErrorMessage)> GetWorkoutByNameAsync(string name)
        {
            try
            {
                logger?.LogInformation("Querying workout");
                var workout = await dbContext.Workouts.FirstOrDefaultAsync(x => x.Name == name);
                if (workout != null)
                {
                    logger?.LogInformation("workout found!");
                    return (true, workout, null);
                }
                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Workout? Workout, string? ErrorMessage)> CreateWorkoutAsync(Workout newWorkout)
        {
            try
            {
                logger?.LogInformation("Creating workout");
                if(newWorkout != null)
                {
                    await this.dbContext.AddAsync(newWorkout);
                    dbContext.SaveChanges();
                    logger?.LogInformation("Workout created!");
                    return (true, newWorkout, null);
                }
                return (false, null, "Workout not created");
            }
            catch (Exception ex)
            {

                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Workout? Workout, string? ErrorMessage)> UpdateWorkoutAsync(Workout updatedWorkout)
        {
            try
            {
                logger?.LogInformation("Finding workout");
                var oldWorkout = await GetWorkoutByIdAsync(updatedWorkout.Id);
                if (oldWorkout.IsSuccess)
                {
                    logger?.LogInformation("found Workout, updating now");
                    oldWorkout.Workout.Name = updatedWorkout.Name;
                    oldWorkout.Workout.WorkoutPlans = updatedWorkout.WorkoutPlans;
                    oldWorkout.Workout.Exercises = updatedWorkout.Exercises;
                    dbContext.SaveChanges();
                    logger?.LogInformation("Workout Updated");
                    return(true, updatedWorkout, null);
                }
                return (false, null, "Workout not Found");
            } 
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Workout? Workout, string? ErrorMessage)> DeleteWorkoutAsync(int id)
        {
            try
            {
                logger?.LogInformation("Finding workout");
                var oldWorkout = await GetWorkoutByIdAsync(id);
                if (oldWorkout.IsSuccess)
                {
                    logger?.LogInformation("found Workout, deleting now");
                    this.dbContext.Remove(oldWorkout.Workout);
                    dbContext.SaveChanges();
                    logger?.LogInformation("Workout deleted");
                    return (true, null, null);
                }
                return (false, null, "Workout not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        private void SeedData()
        {
            if (!dbContext.Workouts.Any())
            {
                
            }
        }
    }
}
