using HomieGainz.ApplicationDb.Db.UserDb;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomieGainz.ApplicationDb.Db.MealDb
{
    public class MealPlan
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(10000)]
        public string Description { get; set; }

        public virtual ICollection<Meal> Meals { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
