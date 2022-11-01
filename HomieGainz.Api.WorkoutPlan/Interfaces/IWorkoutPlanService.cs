using HomieGainz.ApplicationDb.Db.WorkoutDb;

namespace HomieGainz.Api.WorkoutPlans.Interfaces
{
    public interface IWorkoutPlanService
    {
        Task<(bool IsSuccess, IEnumerable<WorkoutPlan>? WorkoutPlans, string? ErrorMessage)> GetWorkoutPlansAsync();
        Task<(bool IsSuccess, WorkoutPlan? WorkoutPlan, string? ErrorMessage)> GetWorkoutPlanByIdAsync(int id);
        Task<(bool IsSuccess, WorkoutPlan? WorkoutPlan, string? ErrorMessage)> AddWorkoutToWorkoutPlanAsync(int workoutId, int workoutPlanId);
        Task<(bool IsSuccess, WorkoutPlan? WorkoutPlan, string? ErrorMessage)> GetWorkoutPlanByNameAsync(string name);
        Task<(bool IsSuccess, WorkoutPlan? WorkoutPlan, string? ErrorMessage)> CreateWorkoutPlanAsync(WorkoutPlan newWorkoutPlan);
        Task<(bool IsSuccess, WorkoutPlan? WorkoutPlan, string? ErrorMessage)> UpdateWorkoutPlanAsync(WorkoutPlan updatedWorkoutPlan);
        Task<(bool IsSuccess, WorkoutPlan? WorkoutPlan, string? ErrorMessage)> DeleteWorkoutPlanAsync(int id);
    }
}
