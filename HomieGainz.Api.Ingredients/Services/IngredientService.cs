using HomieGainz.Api.Ingredients.Interfaces;
using HomieGainz.ApplicationDb.Db.MealDb;
using HomieGainz.UserMeals.Db;

namespace HomieGainz.Api.Ingredients.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ILogger<IngredientService> logger;

        public IngredientService(ApplicationDbContext dbContext, ILogger<IngredientService> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            SeedData();
        }

        public async Task<(bool IsSuccess, Ingredient Ingredient, string ErrorMessage)> CreateIngredientAsync(Ingredient newIngredient)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool IsSuccess, Ingredient Ingredient, string ErrorMessage)> DeleteIngredientAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool IsSuccess, Ingredient Ingredient, string ErrorMessage)> GetIngredientAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool IsSuccess, Ingredient Ingredient, string ErrorMessage)> GetIngredientByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool IsSuccess, IEnumerable<Ingredient> Ingredients, string ErrorMessage)> GetIngredientsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<(bool IsSuccess, Ingredient Ingredient, string ErrorMessage)> UpdateIngredientAsync(Ingredient updatedIngredient)
        {
            throw new NotImplementedException();
        }

        private void SeedData()
        {
            if (!dbContext.Ingredients.Any())
            {
                dbContext.Add(new Ingredient { Name = "Chocolate", Quantity = 2, Measurement = "p" });
                dbContext.Add(new Ingredient { Name = "Flour", Quantity = 20, Measurement = "p" });
                dbContext.Add(new Ingredient { Name = "Chocolate", Quantity = 2, Measurement = "p" });
            }
        }
    }
}
