using HomieGainz.Api.MealPan.Interfaces;
using HomieGainz.ApplicationDb.Db;
using HomieGainz.ApplicationDb.Db.MealDb;
using Microsoft.EntityFrameworkCore;

namespace HomieGainz.Api.MealPan.Services
{
    public class MealPlanService : IMealPlanService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ILogger<MealPlanService> logger;

        public MealPlanService(ApplicationDbContext dbContext, ILogger<MealPlanService> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public async Task<(bool IsSuccess, IEnumerable<MealPlan>? MealPlans, string? ErrorMessage)> GetMealPlansAsync()
        {
            try
            {
                logger?.LogInformation("Querying MealPlans");
                var mealPlans = await dbContext.MealPlans.ToListAsync();
                if (mealPlans != null && mealPlans.Any())
                {
                    logger?.LogInformation($"{mealPlans.Count} mealPlan(s) found");
                    return (true, mealPlans, null);
                }
                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, MealPlan? MealPlan, string? ErrorMessage)> GetMealPlanByIdAsync(int id)
        {
            try
            {
                logger?.LogInformation("Querying mealPlan");
                var mealPlan = await dbContext.MealPlans.Include(m => m.Meals).FirstOrDefaultAsync(x => x.Id == id);
                if (mealPlan != null)
                {
                    logger?.LogInformation("mealPlan found!");
                    return (true, mealPlan, null);
                }
                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, MealPlan? MealPlan, string? ErrorMessage)> GetMealPlanByNameAsync(string name)
        {
            try
            {
                logger?.LogInformation("Querying mealPlan");
                var mealPlan = await dbContext.MealPlans.FirstOrDefaultAsync(x => x.Name == name);
                if (mealPlan != null)
                {
                    logger?.LogInformation("mealPlan found!");
                    return (true, mealPlan, null);
                }
                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
        
        public async Task<(bool IsSuccess, MealPlan? MealPlan, string? ErrorMessage)> CreateMealPlanAsync(MealPlan newMealPlan)
        {
            try
            {
                logger?.LogInformation("Creating MealPlan");
                if (newMealPlan != null)
                {
                    await this.dbContext.AddAsync(newMealPlan);
                    dbContext.SaveChanges();
                    logger?.LogInformation("MealPlan created!");
                    return (true, newMealPlan, null);
                }
                return (false, null, "MealPlan not created");
            }
            catch (Exception ex)
            {

                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, MealPlan? MealPlan, string? ErrorMessage)> UpdateMealPlanAsync(MealPlan updatedMealPlan)
        {
            try
            {
                logger?.LogInformation("Finding MealPlan");
                var oldMealPlan = await GetMealPlanByIdAsync(updatedMealPlan.Id);
                if (oldMealPlan.IsSuccess && oldMealPlan.MealPlan != null)
                {
                    logger?.LogInformation("found Meal, updating now");
                    oldMealPlan.MealPlan.Name = updatedMealPlan.Name;
                    oldMealPlan.MealPlan.Description = updatedMealPlan.Description;
                    oldMealPlan.MealPlan.Meals = updatedMealPlan.Meals;
                    oldMealPlan.MealPlan.Users = updatedMealPlan.Users;
                    dbContext.SaveChanges();
                    logger?.LogInformation("MealPlan Updated");
                    return (true, updatedMealPlan, null);
                }
                return (false, null, "Meal not Found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
        
        public async Task<(bool IsSuccess, MealPlan? MealPlan, string? ErrorMessage)> DeleteMealPlanAsync(int id)
        {
            try
            {
                logger?.LogInformation("Finding MealPlan");
                var oldMealPlan = await GetMealPlanByIdAsync(id);
                if (oldMealPlan.IsSuccess)
                {
                    logger?.LogInformation("found MealPlan, deleting now");
                    dbContext.Remove(oldMealPlan.MealPlan);
                    dbContext.SaveChanges();
                    logger?.LogInformation("MealPlan deleted");
                    return (true, null, null);
                }
                return (false, null, "MealPlan not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
