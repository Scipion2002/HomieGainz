using HomieGainz.Api.Workouts.Interfaces;
using HomieGainz.ApplicationDb.Db.WorkoutDb;
using HomieGainz.UserMeals.Db;
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

        public async Task<(bool? IsSuccess, IEnumerable<Workout>? Workouts, string? ErrorMessage)> GetWorkoutsAsync()
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
        public async Task<(bool? IsSuccess, Workout? Workout, string? ErrorMessage)> GetWorkoutByIdAsync(int id)
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

        public async Task<(bool? IsSuccess, Workout? Workout, string? ErrorMessage)> GetWorkoutAsync(string name)
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

        public async Task<(bool? IsSuccess, Workout? Workout, string? ErrorMessage)> CreateWorkoutAsync(Workout newWorkout)
        {
            try
            {
                logger?.LogInformation("Creating workout");
                if(newWorkout != null)
                {
                    await this.dbContext.AddAsync(newWorkout);
                    dbContext.SaveChanges();
                    logger?.LogInformation("User created");
                    return (true, newWorkout, null);
                }
                return (false, null, "User not created");
            }
            catch (Exception ex)
            {

                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public Task<(bool? IsSuccess, Workout? Workout, string? ErrorMessage)> UpdateWorkoutAsync(Workout updatedWorkout)
        {
            throw new NotImplementedException();
        }

        public Task<(bool? IsSuccess, Workout? Workout, string? ErrorMessage)> DeleteWorkoutAsync(int id)
        {
            throw new NotImplementedException();
        }

        private void SeedData()
        {
            if (!dbContext.Workouts.Any())
            {
                dbContext.Workouts.Add(new Workout() { Name = "Upper Body"});
                dbContext.Workouts.Add(new Workout() { Name = "Lower Body" });

                dbContext.SaveChanges();
            }
        }
    }
}
