using HomieGainz.Api.MealPan.Interfaces;
using HomieGainz.ApplicationDb.Db.MealDb;

namespace HomieGainz.Api.MealPan
{
    public class MealPlanService : IMealPlanService
    {
        public Task<(bool IsSuccess, MealPlan? MealPlan, string? ErrorMessage)> CreateMealPlanAsync(MealPlan newMealPlan)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccess, MealPlan? MealPlan, string? ErrorMessage)> DeleteMealPlanAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccess, MealPlan? MealPlan, string? ErrorMessage)> GetMealPlanByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccess, MealPlan? MealPlan, string? ErrorMessage)> GetMealPlanByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccess, IEnumerable<MealPlan>? MealPlans, string? ErrorMessage)> GetMealPlansAsync()
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccess, MealPlan? MealPlan, string? ErrorMessage)> UpdateMealPlanAsync(MealPlan updatedMealPlan)
        {
            throw new NotImplementedException();
        }
    }
}
