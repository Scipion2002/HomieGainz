using HomieGainz.Api.Meals.Interfaces;
using HomieGainz.ApplicationDb.Db.MealDb;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomieGainz.Api.Meals.Services
{
    internal class MealService : IMealService
    {

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

    }
}