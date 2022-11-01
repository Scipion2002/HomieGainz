using HomieGainz.ApplicationDb.Models.Users;

namespace HomieGainz.Api.Friendships.Interfaces
{
    public interface IFriendshipService
    {
        Task<(bool IsSuccess, Friendship? Friendship, string? ErrorMessage)> GetAllFriendshipRequests();
        Task<(bool IsSuccess, Friendship? Friendship, string? ErrorMessage)> SendFriendRequestAsync(int fromUserId, int toUserId);
        Task<(bool IsSuccess, Friendship? Friendship, string? ErrorMessage)> AcceptFriendRequestAsync(int toUserId, int fromUserId);
        Task<(bool IsSuccess, Friendship? Friendship, string? ErrorMessage)> RejectFriendRequestAsync(int toUserId, int fromUserId);
    }
}
