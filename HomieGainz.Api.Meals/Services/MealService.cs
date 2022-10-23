using HomieGainz.Api.Meals.Interfaces;
using HomieGainz.ApplicationDb.Db.MealDb;
using HomieGainz.ApplicationDb.Db;
using Microsoft.Build.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HomieGainz.Api.Meals.Services
{
    internal class MealService : IMealService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ILogger<MealService> logger;

        public MealService(ApplicationDbContext dbContext, ILogger<MealService> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            SeedData();
        }

        public async Task<(bool IsSuccess, IEnumerable<Meal> Meals, string ErrorMessage)> GetMealsAsync()
        {
            try
            {
                logger?.LogInformation("Querying Meals");
                var meals = await dbContext.Meals.ToListAsync();
                if (meals != null && meals.Any())
                {
                    logger?.LogInformation($"{meals.Count} meal(s) found");
                    return (true, meals, null);
                }
                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Meal Meal, string ErrorMessage)> GetMealByIdAsync(int id)
        {
            try
            {
                logger?.LogInformation("Querying meal");
                var meal = await dbContext.Meals.FirstOrDefaultAsync(x => x.Id == id);
                if (meal != null)
                {
                    logger?.LogInformation("meal found!");
                    return (true, meal, null);
                }
                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Meal Meal, string ErrorMessage)> GetMealByNameAsync(string name)
        {
            try
            {
                logger?.LogInformation("Querying meal");
                var meal = await dbContext.Meals.FirstOrDefaultAsync(x => x.Name == name);
                if (meal != null)
                {
                    logger?.LogInformation("meal found!");
                    return (true, meal, null);
                }
                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Meal Meal, string ErrorMessage)> CreateMealAsync(Meal newMeal)
        {
            try
            {
                logger?.LogInformation("Creating Meal");
                if (newMeal != null)
                {
                    await this.dbContext.AddAsync(newMeal);
                    dbContext.SaveChanges();
                    logger?.LogInformation("Meal created!");
                    return (true, newMeal, null);
                }
                return (false, null, "Meal not created");
            }
            catch (Exception ex)
            {

                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Meal Meal, string ErrorMessage)> UpdateMealAsync(Meal updatedMeal)
        {
            try
            {
                logger?.LogInformation("Finding Meal");
                var oldMeal = await GetMealByIdAsync(updatedMeal.Id);
                if (oldMeal.IsSuccess)
                {
                    logger?.LogInformation("found Meal, updating now");
                    oldMeal.Meal.Name = updatedMeal.Name;
                    oldMeal.Meal.Description = updatedMeal.Description;
                    oldMeal.Meal.ImgLink = updatedMeal.ImgLink;
                    oldMeal.Meal.IngredientList = updatedMeal.IngredientList;
                    oldMeal.Meal.Directions = updatedMeal.Directions;
                    oldMeal.Meal.MealPlans = updatedMeal.MealPlans;
                    dbContext.SaveChanges();
                    logger?.LogInformation("Meal Updated");
                    return (true, updatedMeal, null);
                }
                return (false, null, "Meal not Found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Meal Meal, string ErrorMessage)> DeleteMealAsync(int id)
        {
            try
            {
                logger?.LogInformation("Finding Meal");
                var oldMeal = await GetMealByIdAsync(id);
                if (oldMeal.IsSuccess)
                {
                    logger?.LogInformation("found Meal, deleting now");
                    this.dbContext.Remove(oldMeal.Meal);
                    dbContext.SaveChanges();
                    logger?.LogInformation("Meal deleted");
                    return (true, null, null);
                }
                return (false, null, "Meal not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        private void SeedData()
        {
            if (!dbContext.Meals.Any())
            {

            }
        }

    }
}