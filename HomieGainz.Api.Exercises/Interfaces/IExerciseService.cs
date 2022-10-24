using HomieGainz.ApplicationDb.Db.WorkoutDb;

namespace HomieGainz.Api.Exercises.Interfaces
{
    public interface IExerciseService
    {
        Task<(bool IsSuccess, IEnumerable<Exercise>? Exercises, string? ErrorMessage)> GetExercisesAsync();
        Task<(bool IsSuccess, Exercise? Exercise, string? ErrorMessage)> GetExerciseByIdAsync(int id);
        Task<(bool IsSuccess, Exercise? Exercise, string? ErrorMessage)> GetExerciseByNameAsync(string name);
        Task<(bool IsSuccess, Exercise? Exercise, string? ErrorMessage)> CreateExerciseAsync(Exercise newExercise);
        Task<(bool IsSuccess, Exercise? Exercise, string? ErrorMessage)> UpdateExerciseAsync(Exercise updatedExercise);
        Task<(bool IsSuccess, Exercise? Exercise, string? ErrorMessage)> DeleteExerciseAsync(int id);
    }
}
