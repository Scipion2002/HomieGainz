using HomieGainz.ApplicationDb.Db.UserDb;
using HomieGainz.ApplicationDb.Db.WorkoutDb;
using Microsoft.Build.Framework;

namespace HomieGainz.ApplicationDb.Models.Users
{
    public class Challenge
    {
        public int Id { get; set; }
        
        [Required]
        public virtual User FromUser { get; set; }

        [Required]
        public virtual User ToUser { get; set; }

        [Required]
        public virtual Workout Workout { get; set; }
        public bool Accepted { get; set; } = false;
    }
}
