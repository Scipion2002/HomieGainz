using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomieGainz.ApplicationDb.Db.MealDb
{
    public class Meal
    {
        
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(10000)]
        public string Description { get; set; }
        public string ImgLink { get; set; }

        public ICollection<MealPlan> MealPlans { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
    }
}
