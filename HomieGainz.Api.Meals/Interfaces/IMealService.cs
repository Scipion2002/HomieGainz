using HomieGainz.ApplicationDb.Db.MealDb;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomieGainz.Api.Meals.Interfaces
{
    public interface IMealService
    {
        Task<(bool IsSuccess, IEnumerable<Meal> Meals, string ErrorMessage)> GetMealsAsync();
        Task<(bool IsSuccess, Meal Meal, string ErrorMessage)> GetMealByIdAsync(int id);
        Task<(bool IsSuccess, Meal Meal, string ErrorMessage)> GetMealByNameAsync(string name);
        Task<(bool IsSuccess, Meal Meal, string ErrorMessage)> CreateMealAsync(Meal newMeal);
        Task<(bool IsSuccess, Meal Meal, string ErrorMessage)> UpdateMealAsync(Meal updatedMeal);
        Task<(bool IsSuccess, Meal Meal, string ErrorMessage)> DeleteMealAsync(int id);
    }
}