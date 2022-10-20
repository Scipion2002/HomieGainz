using HomieGainz.Api.Workout.Interfaces;
using HomieGainz.UserMeals.Db;

namespace HomieGainz.Api.Workout.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ILogger<WorkoutService> logger;

        public WorkoutService(ApplicationDbContext dbContext, ILogger<WorkoutService> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            SeedData();
        }

        public Task<(bool IsSuccess, ApplicationDb.Db.WorkoutDb.Workout Workout, string ErrorMessage)> CreateWorkoutAsync(ApplicationDb.Db.WorkoutDb.Workout newWorkout)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccess, ApplicationDb.Db.WorkoutDb.Workout Workout, string ErrorMessage)> DeleteWorkoutAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccess, ApplicationDb.Db.WorkoutDb.Workout Workout, string ErrorMessage)> GetWorkoutAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccess, ApplicationDb.Db.WorkoutDb.Workout Workout, string ErrorMessage)> GetWorkoutByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccess, IEnumerable<ApplicationDb.Db.WorkoutDb.Workout> Workouts, string ErrorMessage)> GetWorkoutsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccess, ApplicationDb.Db.WorkoutDb.Workout Workout, string ErrorMessage)> UpdateWorkoutAsync(ApplicationDb.Db.WorkoutDb.Workout updatedWorkout)
        {
            throw new NotImplementedException();
        }

        private void SeedData()
        {
            if (!dbContext.Workouts.Any())
            {
                dbContext.Workouts.Add(new ApplicationDb.Db.WorkoutDb.Workout() { Name = "Upper Body"});
                dbContext.SaveChanges();
            }
        }
    }
}
