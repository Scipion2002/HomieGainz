using HomieGainz.Api.WorkoutPlans.Interfaces;
using HomieGainz.ApplicationDb.Db;
using HomieGainz.ApplicationDb.Db.WorkoutDb;
using Microsoft.EntityFrameworkCore;

namespace HomieGainz.Api.WorkoutPlans.Services
{
    public class WorkoutPlanService : IWorkoutPlanService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ILogger<WorkoutPlanService> logger;

        public WorkoutPlanService(ApplicationDbContext dbContext, ILogger<WorkoutPlanService> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public async Task<(bool IsSuccess, IEnumerable<WorkoutPlan>? WorkoutPlans, string? ErrorMessage)> GetWorkoutPlansAsync()
        {
            try
            {
                logger?.LogInformation("Querying workoutPlans");
                var workoutPlans = await dbContext.WorkoutPlans.ToListAsync();
                if (workoutPlans != null && workoutPlans.Any())
                {
                    logger?.LogInformation($"{workoutPlans.Count} workoutPlan(s) found");
                    return (true, workoutPlans, null);
                }
                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
        
        public async Task<(bool IsSuccess, WorkoutPlan? WorkoutPlan, string? ErrorMessage)> GetWorkoutPlanByIdAsync(int id)
        {
            try
            {
                logger?.LogInformation("Querying workoutPlan");
                var workoutPlan = await dbContext.WorkoutPlans.Include(w => w.Workouts).ThenInclude(e => e.Exercises).FirstOrDefaultAsync(x => x.Id == id);
                if (workoutPlan != null)
                {
                    logger?.LogInformation("workoutPlan found!");
                    return (true, workoutPlan, null);
                }
                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, WorkoutPlan? WorkoutPlan, string? ErrorMessage)> AddWorkoutToWorkoutPlanAsync(int workoutId, int workoutPlanId)
        {
            try
            {
                logger?.LogInformation("Querying workoutPlan");
                var workoutPlan = await dbContext.WorkoutPlans.Include(w => w.Workouts).FirstOrDefaultAsync(x => x.Id == workoutPlanId);
                if (workoutPlan != null)
                {
                    logger?.LogInformation("found workoutPlan, getting workout to add");
                    var workout = await dbContext.Workouts.Where(x => x.Id == workoutId).FirstOrDefaultAsync();
                    if (workout != null)
                    {
                        logger?.LogInformation("found workout, adding workout to workout plan");
                        workoutPlan.Workouts.Add(workout);
                        dbContext.SaveChanges();
                        logger?.LogInformation("Done");
                        return (true, workoutPlan, null);
                    }
                    return (false, null, "workout not found");
                }
                return (false, null, "workout plan not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, WorkoutPlan? WorkoutPlan, string? ErrorMessage)> DeleteWorkoutFromWorkoutPlanAsync(int workoutId, int workoutPlanId)
        {
            try
            {
                logger?.LogInformation("Querying workoutPlan");
                var workoutPlan = await dbContext.WorkoutPlans.Include(w => w.Workouts).FirstOrDefaultAsync(x => x.Id == workoutPlanId);
                if (workoutPlan != null)
                {
                    logger?.LogInformation("found workoutPlan, getting workout to delete");
                    var workout = await dbContext.Workouts.Where(x => x.Id == workoutId).FirstOrDefaultAsync();
                    if (workout != null)
                    {
                        logger?.LogInformation("found workout, deleting workout from workout plan");
                        workoutPlan.Workouts.Remove(workout);
                        dbContext.SaveChanges();
                        logger?.LogInformation("Done");
                        return (true, workoutPlan, null);
                    }
                    return (false, null, "workout not found");
                }
                return (false, null, "workout plan not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, WorkoutPlan? WorkoutPlan, string? ErrorMessage)> GetWorkoutPlanByNameAsync(string name)
        {
            try
            {
                logger?.LogInformation("Querying workoutPlan");
                var workoutPlan = await dbContext.WorkoutPlans.FirstOrDefaultAsync(x => x.Name == name);
                if (workoutPlan != null)
                {
                    logger?.LogInformation("workoutPlan found!");
                    return (true, workoutPlan, null);
                }
                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
        
        public async Task<(bool IsSuccess, WorkoutPlan? WorkoutPlan, string? ErrorMessage)> CreateWorkoutPlanAsync(WorkoutPlan newWorkoutPlan)
        {
            try
            {
                logger?.LogInformation("Creating workoutPlan");
                if (newWorkoutPlan != null)
                {
                    await this.dbContext.AddAsync(newWorkoutPlan);
                    dbContext.SaveChanges();
                    logger?.LogInformation("WorkoutPlan created!");
                    return (true, newWorkoutPlan, null);
                }
                return (false, null, "WorkoutPlan not created");
            }
            catch (Exception ex)
            {

                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, WorkoutPlan? WorkoutPlan, string? ErrorMessage)> UpdateWorkoutPlanAsync(WorkoutPlan updatedWorkoutPlan)
        {
            try
            {
                logger?.LogInformation("Finding workoutPlan");
                var oldWorkoutPlan = await GetWorkoutPlanByIdAsync(updatedWorkoutPlan.Id);
                if (oldWorkoutPlan.IsSuccess && oldWorkoutPlan.WorkoutPlan != null)
                {
                    logger?.LogInformation("found Workout, updating now");
                    oldWorkoutPlan.WorkoutPlan.Name = updatedWorkoutPlan.Name;
                    oldWorkoutPlan.WorkoutPlan.Description = updatedWorkoutPlan.Description;
                    oldWorkoutPlan.WorkoutPlan.Workouts = updatedWorkoutPlan.Workouts;
                    oldWorkoutPlan.WorkoutPlan.Users = updatedWorkoutPlan.Users;
                    dbContext.SaveChanges();
                    logger?.LogInformation("WorkoutPlan Updated");
                    return (true, updatedWorkoutPlan, null);
                }
                return (false, null, "WorkoutPlan not Found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, WorkoutPlan? WorkoutPlan, string? ErrorMessage)> DeleteWorkoutPlanAsync(int id)
        {
            try
            {
                logger?.LogInformation("Finding workoutPlan");
                var oldWorkoutPlan = await GetWorkoutPlanByIdAsync(id);
                if (oldWorkoutPlan.IsSuccess)
                {
                    logger?.LogInformation("found WorkoutPlan, deleting now");
                    this.dbContext.Remove(oldWorkoutPlan.WorkoutPlan);
                    dbContext.SaveChanges();
                    logger?.LogInformation("WorkoutPlan deleted");
                    return (true, null, null);
                }
                return (false, null, "WorkoutPlan not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
