using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomieGainz.ApplicationDb.Db.WorkoutDb
{
    public class WorkoutPlan
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(10000)]
        public string Description { get; set; }

        public ICollection<Workout> Workouts { get; set; }

        public ICollection<UserDb.User> Users { get; set; }
    }
}
