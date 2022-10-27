
using HomieGainz.ApplicationDb.Db.UserDb;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomieGainz.Api.Application.Interfaces
{
    public interface IUserService
    {
        Task<(bool IsSuccess, IEnumerable<User> Users, string ErrorMessage)> GetUsersAsync();
        Task<(bool IsSuccess, User User, string ErrorMessage)> GetUserByIdAsync(int id);
        Task<(bool IsSuccess, User User, string ErrorMessage)> GetUserAsync(string username);
        Task<(bool IsSuccess, User User, string ErrorMessage)> GetQuestionaireTotalAsync(User user, int total);
        Task<(bool IsSuccess, User User, string ErrorMessage)> ChangeMealPlanAsync(User user, int mealPlanId);
        Task<(bool IsSuccess, User User, string ErrorMessage)> CreateUserAsync(User newUser);
        Task<(bool IsSuccess, User User, string ErrorMessage)> UpdateUserAsync(User updatedUser);
        Task<(bool IsSuccess, User User, string ErrorMessage)> DeleteUserAsync(int id);

    }
}
