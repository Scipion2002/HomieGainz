using HomieGainz.ApplicationDb.Db.WorkoutDb;
namespace HomieGainz.Api.Workout.Interfaces
{
    public interface IWorkoutService
    {
        Task<(bool IsSuccess, IEnumerable<ApplicationDb.Db.WorkoutDb.Workout> Workouts, string ErrorMessage)> GetWorkoutsAsync();
        Task<(bool IsSuccess, ApplicationDb.Db.WorkoutDb.Workout Workout, string ErrorMessage)> GetWorkoutByIdAsync(int id);
        Task<(bool IsSuccess, ApplicationDb.Db.WorkoutDb.Workout Workout, string ErrorMessage)> GetWorkoutAsync(string name);
        Task<(bool IsSuccess, ApplicationDb.Db.WorkoutDb.Workout Workout, string ErrorMessage)> CreateWorkoutAsync(ApplicationDb.Db.WorkoutDb.Workout newWorkout);
        Task<(bool IsSuccess, ApplicationDb.Db.WorkoutDb.Workout Workout, string ErrorMessage)> UpdateWorkoutAsync(ApplicationDb.Db.WorkoutDb.Workout updatedWorkout);
        Task<(bool IsSuccess, ApplicationDb.Db.WorkoutDb.Workout Workout, string ErrorMessage)> DeleteWorkoutAsync(int id);
    }
}