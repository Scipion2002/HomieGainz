using System.ComponentModel.DataAnnotations;

namespace HomieGainz.ApplicationDb.Db.UserDb
{
    public class User
    {

        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Range(0,125)]
        public int Age { get; set; }
        [Required]
        [Range(0, 1071)]
        public int Weight { get; set; }
        [Required]
        [Range(0, 8.9)]
        public double Height { get; set; }
        public MealDb.MealPlan MealPlan { get; set; }
        public WorkoutDb.WorkoutPlan WorkoutPlan { get; set; }
    }
}
