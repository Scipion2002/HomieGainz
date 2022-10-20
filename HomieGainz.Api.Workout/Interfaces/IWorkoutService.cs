using HomieGainz.ApplicationDb.Db.WorkoutDb;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomieGainz.Api.Workouts.Interfaces
{
    public interface IWorkoutService
    {
        Task<(bool IsSuccess, IEnumerable<Workout>? Workouts, string? ErrorMessage)> GetWorkoutsAsync();
        Task<(bool IsSuccess, Workout? Workout, string? ErrorMessage)> GetWorkoutByIdAsync(int id);
        Task<(bool IsSuccess, Workout? Workout, string? ErrorMessage)> GetWorkoutByNameAsync(string name);
        Task<(bool IsSuccess, Workout? Workout, string? ErrorMessage)> CreateWorkoutAsync(Workout newWorkout);
        Task<(bool IsSuccess, Workout? Workout, string? ErrorMessage)> UpdateWorkoutAsync(Workout updatedWorkout);
        Task<(bool IsSuccess, Workout? Workout, string? ErrorMessage)> DeleteWorkoutAsync(int id);
    }
}