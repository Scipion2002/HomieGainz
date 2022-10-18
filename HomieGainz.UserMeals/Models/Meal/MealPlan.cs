using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public ICollection<Meal> Meals { get; set; }

        public ICollection<UserDb.User> Users { get; set; }
    }
}
