
using HomieGainz.ApplicationDb.Db.UserDb;
using HomieGainz.ApplicationDb.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomieGainz.Api.Application.Interfaces
{
    public interface IUserService
    {
        Task<(bool IsSuccess, IEnumerable<User> Users, string ErrorMessage)> GetUsersAsync();
        Task<(bool IsSuccess, Friendship Friendship, string ErrorMessage)> SendFriendRequestAsync(int fromUserId, int toUserId);        
        Task<(bool IsSuccess, Friendship Friendship, string ErrorMessage)> AcceptFriendRequestAsync(int toUserId, int fromUserId);        
        Task<(bool IsSuccess, Friendship Friendship, string ErrorMessage)> RejectFriendRequestAsync(int toUserId, int fromUserId);        
        Task<(bool IsSuccess, User User, string ErrorMessage)> GetUserByIdAsync(int id);
        Task<(bool IsSuccess, User User, string ErrorMessage)> GetUserAsync(string username);
        Task<(bool IsSuccess, User User, string ErrorMessage)> GetQuestionaireTotalAsync(int id, int total);
        Task<(bool IsSuccess, User User, string ErrorMessage)> ChangeMealPlanAsync(int userId, int mealPlanId);
        Task<(bool IsSuccess, User User, string ErrorMessage)> ChangeWorkoutPlanAsync(int userId, int workoutPlanId);
        Task<(bool IsSuccess, User User, string ErrorMessage)> CreateUserAsync(User newUser);
        Task<(bool IsSuccess, User User, string ErrorMessage)> UpdateUserAsync(User updatedUser);
        Task<(bool IsSuccess, User User, string ErrorMessage)> DeleteUserAsync(int id);

    }
}
