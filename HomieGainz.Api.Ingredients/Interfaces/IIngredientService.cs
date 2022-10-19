using HomieGainz.ApplicationDb.Db.MealDb;

namespace HomieGainz.Api.Ingredients.Interfaces
{
    public interface IIngredientService
    {
        Task<(bool IsSuccess, IEnumerable<Ingredient> Ingredients, string ErrorMessage)> GetIngredientsAsync();
        Task<(bool IsSuccess, Ingredient Ingredient, string ErrorMessage)> GetIngredientByIdAsync(int id);
        Task<(bool IsSuccess, Ingredient Ingredient, string ErrorMessage)> GetIngredientAsync(string name);
        Task<(bool IsSuccess, Ingredient Ingredient, string ErrorMessage)> CreateIngredientAsync(Ingredient newIngredient);
        Task<(bool IsSuccess, Ingredient Ingredient, string ErrorMessage)> UpdateIngredientAsync(Ingredient updatedIngredient);
        Task<(bool IsSuccess, Ingredient Ingredient, string ErrorMessage)> DeleteIngredientAsync(int id);
    }
}
