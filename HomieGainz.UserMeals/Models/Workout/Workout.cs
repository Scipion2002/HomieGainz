using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomieGainz.ApplicationDb.Db.WorkoutDb
{
    public class Workout
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<WorkoutPlan> WorkoutPlans { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
    }
}
