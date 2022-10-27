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

        public virtual ICollection<WorkoutPlan> WorkoutPlans { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
