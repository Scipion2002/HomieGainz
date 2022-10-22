using HomieGainz.Api.Meals.Interfaces;
using HomieGainz.ApplicationDb.Db.MealDb;
using HomieGainz.ApplicationDb.Db;
using Microsoft.Build.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

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

        public Task<(bool IsSuccess, IEnumerable<Meal> Meals, string ErrorMessage)> GetMealsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<(bool IsSuccess, Meal Meal, string ErrorMessage)> GetMealByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<(bool IsSuccess, Meal Meal, string ErrorMessage)> GetMealByNameAsync(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task<(bool IsSuccess, Meal Meal, string ErrorMessage)> CreateMealAsync(Meal newMeal)
        {
            throw new System.NotImplementedException();
        }

        public Task<(bool IsSuccess, Meal Meal, string ErrorMessage)> UpdateMealAsync(Meal updatedMeal)
        {
            throw new System.NotImplementedException();
        }

        public Task<(bool IsSuccess, Meal Meal, string ErrorMessage)> DeleteMealAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        private void SeedData()
        {
            if (!dbContext.Meals.Any())
            {

            }
        }

    }
}