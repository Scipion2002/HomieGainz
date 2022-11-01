using HomieGainz.Api.Friendships.Interfaces;
using HomieGainz.ApplicationDb.Db;
using HomieGainz.ApplicationDb.Db.UserDb;
using HomieGainz.ApplicationDb.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HomieGainz.Api.Friendships.Services
{
    public class FriendshipsService : IFriendshipService
    {

        private readonly ApplicationDbContext dbContext;
        private readonly ILogger<FriendshipsService> logger;

        public FriendshipsService(ApplicationDbContext dbContext, ILogger<FriendshipsService> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }
        public async Task<(bool IsSuccess, User? User, string? ErrorMessage)> GetUserByIdAsync(int id)
        {
            try
            {
                logger?.LogInformation("Querying user");
                var user = await this.dbContext.Users.Where(u => id == u.Id)
                    .Include(m => m.MealPlan).Include(w => w.WorkoutPlan).Include(f => f.Friends).FirstOrDefaultAsync();
                if (user != null)
                {
                    logger?.LogInformation("User found");
                    return (true, user, null);
                }
                return (false, null, "Not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Friendship? Friendship, string? ErrorMessage)> SendFriendRequestAsync(int fromUserId, int toUserId)
        {
            try
            {
                logger?.LogInformation("Finding fromUser");
                var fromUser = await GetUserByIdAsync(fromUserId);
                if (fromUser.IsSuccess)
                {
                    logger?.LogInformation("found fromUser, finding toUser");
                    var toUser = await GetUserByIdAsync(toUserId);
                    if (toUser.IsSuccess)
                    {
                        logger?.LogInformation("found toUser, sending request...");
                        var friendRequest = dbContext.Friendships.Add(new Friendship() { FromUser = fromUser.User, ToFriend = toUser.User });
                        dbContext.SaveChanges();
                        logger?.LogInformation("Request has been sent!");
                        return (true, friendRequest.Entity, null);
                    }
                    return (false, null, "toUser not found");
                }
                return (false, null, "fromUser not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Friendship? Friendship, string? ErrorMessage)> AcceptFriendRequestAsync(int toUserId, int fromUserId)
        {
            try
            {
                logger?.LogInformation("Finding toUser");
                var toUser = await GetUserByIdAsync(toUserId);
                if (toUser.IsSuccess)
                {
                    logger?.LogInformation("found toUser, finding fromUser");
                    var fromUser = await GetUserByIdAsync(fromUserId);
                    if (fromUser.IsSuccess)
                    {
                        logger?.LogInformation("found fromUser");
                        Friendship? pendingFriendship = await dbContext.Friendships
                            .Where(u => u.FromUser.Id == fromUserId && u.ToFriend.Id == toUserId).FirstOrDefaultAsync();

                        if (pendingFriendship != null)
                        {
                            logger?.LogInformation("found pending friendship, accepting now");
                            pendingFriendship.Accepted = true;

                            logger?.LogInformation("friendship accepted, adding to friends");
                            toUser.User?.Friends.Add(fromUser.User);
                            fromUser.User?.Friends.Add(toUser.User);

                            dbContext.SaveChanges();
                            logger?.LogInformation("done");
                            return (true, pendingFriendship, null);
                        }
                        return (false, null, "pending friendship is null");
                        
                    }
                    return (false, null, "fromUser not found");
                }
                return (false, null, "toUser not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Friendship? Friendship, string? ErrorMessage)> RejectFriendRequestAsync(int toUserId, int fromUserId)
        {
            try
            {
                logger?.LogInformation("Finding toUser");
                var toUser = await GetUserByIdAsync(toUserId);
                if (toUser.IsSuccess)
                {
                    logger?.LogInformation("found toUser, finding fromUser");
                    var fromUser = await GetUserByIdAsync(fromUserId);
                    if (fromUser.IsSuccess)
                    {
                        logger?.LogInformation("found fromUser");
                        Friendship? pendingFriendship = await dbContext.Friendships
                            .Where(u => u.FromUser.Id == fromUserId && u.ToFriend.Id == toUserId).FirstOrDefaultAsync();
                        if (pendingFriendship != null)
                        {
                            logger?.LogInformation("found pending friendship, rejecting now");
                            dbContext.Friendships.Remove(pendingFriendship);

                            dbContext.SaveChanges();
                            logger?.LogInformation("done");
                            return (true, pendingFriendship, null);
                        }
                        return (false, null, "pending friendship is null");
                    }
                    return (false, null, "fromUser not found");
                }
                return (false, null, "toUser not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public Task<(bool IsSuccess, Friendship? Friendship, string? ErrorMessage)> GetAllFriendshipRequests()
        {
            throw new NotImplementedException();
        }
    }
}
