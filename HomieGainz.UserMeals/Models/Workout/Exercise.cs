using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomieGainz.ApplicationDb.Db.WorkoutDb
{
    public class Exercise
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string TargetMuscle { get; set; }
        public string Video { get; set; }

        [Range(0, 100)]
        public int SetAmt { get; set; }
        [Range(0, 100)]
        public int RepAmt { get; set; }
        [MaxLength(10000)]
        public string Description { get; set; }

        public ICollection<Workout> Workouts { get; set; }
    }
}
