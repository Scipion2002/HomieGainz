using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomieGainz.ApplicationDb.Db.MealDb
{
    public class Ingredient
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [Range(0,100)]
        public int Quantity { get; set; }
        [Required]
        [MaxLength(10)]
        public string Measurement { get; set; }

        public ICollection<Meal> Meals { get; set; }
    }
}
