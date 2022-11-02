using HomieGainz.ApplicationDb.Models.Users;

namespace HomieGainz.Api.Challenges.Interfaces
{
    public interface IChallengeService
    {
        Task<(bool IsSuccess, IEnumerable<Challenge>? Challenges, string? ErrorMessage)> GetAllChallengeRequestsFromUser(int userId);
        Task<(bool IsSuccess, Challenge? Challenge, string? ErrorMessage)> SendChallengeRequestAsync(int fromUserId, int toUserId, int workoutId);
        Task<(bool IsSuccess, Challenge? Challenge, string? ErrorMessage)> AcceptChallengeRequestAsync(int toUserId, int fromUserId, int workoutId);
        Task<(bool IsSuccess, Challenge? Challenge, string? ErrorMessage)> RejectChallengeRequestAsync(int toUserId, int fromUserId, int workoutId);
    }
}
