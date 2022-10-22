using HomieGainz.ApplicationDb.Db.MealDb;

namespace HomieGainz.Api.MealPan.Interfaces
{
    public interface IMealPlanService
    {
        Task<(bool IsSuccess, IEnumerable<MealPlan>? MealPlans, string? ErrorMessage)> GetMealPlansAsync();
        Task<(bool IsSuccess, MealPlan? MealPlan, string? ErrorMessage)> GetMealPlanByIdAsync(int id);
        Task<(bool IsSuccess, MealPlan? MealPlan, string? ErrorMessage)> GetMealPlanByNameAsync(string name);
        Task<(bool IsSuccess, MealPlan? MealPlan, string? ErrorMessage)> CreateMealPlanAsync(MealPlan newMealPlan);
        Task<(bool IsSuccess, MealPlan? MealPlan, string? ErrorMessage)> UpdateMealPlanAsync(MealPlan updatedMealPlan);
        Task<(bool IsSuccess, MealPlan? MealPlan, string? ErrorMessage)> DeleteMealPlanAsync(int id);
    }
}
