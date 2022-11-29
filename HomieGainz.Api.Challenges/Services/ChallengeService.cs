using HomieGainz.Api.Challenges.Interfaces;
using HomieGainz.ApplicationDb.Db;
using HomieGainz.ApplicationDb.Db.UserDb;
using HomieGainz.ApplicationDb.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace HomieGainz.Api.Challenges.Services
{
    public class ChallengeService : IChallengeService
    {

        private readonly ApplicationDbContext dbContext;
        private readonly ILogger<ChallengeService> logger;

        public ChallengeService(ApplicationDbContext dbContext, ILogger<ChallengeService> logger)
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
                    .Include(w => w.WorkoutPlan).Include(f => f.Friends).FirstOrDefaultAsync();
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

        public async Task<(bool IsSuccess, IEnumerable<Challenge>? Challenges, string? ErrorMessage)> GetAllChallengeRequestsFromUser(int userId)
        {
            try
            {
                logger?.LogInformation("Querying user");
                var user = await GetUserByIdAsync(userId);
                if (user.User != null)
                {
                    logger?.LogInformation("User found, getting friendship requests");
                    var challengeRequests = await dbContext.Challenges.Where(t => t.ToUser.Id == userId && !t.Accepted).Include(f => f.FromUser).Include(w => w.Workout).ToListAsync();
                    if (challengeRequests != null && challengeRequests.Any())
                    {
                        logger?.LogInformation($"{challengeRequests.Count} request(s) found");
                        return (true, challengeRequests, null);
                    }
                    return (false, null, null);
                }
                return (false, null, null);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Challenge? Challenge, string? ErrorMessage)> SendChallengeRequestAsync(int fromUserId, int toUserId, int workoutId)
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
                        logger?.LogInformation("found toUser, getting the workout to go...");
                        var workoutChallenge = await dbContext.Workouts.Where(w => w.Id == workoutId).Include(w => w.Exercises).FirstOrDefaultAsync();
                        if (workoutChallenge != null)
                        {
                            logger?.LogInformation("Found workout, sending request");
                            var workoutRequest = await dbContext.Challenges.AddAsync(new Challenge { FromUser = fromUser.User, ToUser = toUser.User, Workout = workoutChallenge });
                            dbContext.SaveChanges();
                            logger?.LogInformation("Request has been sent!");
                            return (true, workoutRequest.Entity, null);
                        }
                        return (false, null, "workout not found");
                    }
                    return (false, null, "toUser not found");
                }
                return (false, null, "From user not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Challenge? Challenge, string? ErrorMessage)> AcceptChallengeRequestAsync(int toUserId, int fromUserId, int workoutId)
        {
            try
            {
                logger?.LogInformation("Finding fromUser");
                var fromUser = await GetUserByIdAsync(fromUserId);
                if (fromUser.IsSuccess)
                {
                    logger?.LogInformation("found fromUser, finding toUser");
                    var toUser = await dbContext.Users.Where(u => toUserId == u.Id).Include(w => w.WorkoutPlan).Include(w => w.WorkoutPlan.Workouts).FirstOrDefaultAsync();
                    if (toUser != null)
                    {
                        logger?.LogInformation("found fromUser, getting workout");
                        var workoutChallenge = await dbContext.Workouts.Where(w => w.Id == workoutId).Include(w => w.Exercises).FirstOrDefaultAsync();
                        if (workoutChallenge != null)
                        {
                            logger?.LogInformation("Found workout, getting request");
                            Challenge? pendingChallenge = await dbContext.Challenges.Where(
                                c => c.ToUser.Id == toUserId 
                                && c.FromUser.Id == fromUserId
                                && c.Workout.Id == workoutChallenge.Id).FirstOrDefaultAsync();
                            if (pendingChallenge != null)
                            {
                                logger?.LogInformation("found request, accepting it now");
                                pendingChallenge.Accepted = true;
                                toUser.WorkoutPlan.Workouts.Add(workoutChallenge);
                                dbContext.SaveChanges();
                                logger?.LogInformation("Done");
                                return (true, pendingChallenge, null);
                            }
                            return (false, null, "pending challenge didn't got Accepted");
                        }
                        return (false, null, "workout not found");
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

        public async Task<(bool IsSuccess, Challenge? Challenge, string? ErrorMessage)> RejectChallengeRequestAsync(int toUserId, int fromUserId, int workoutId)
        {
            try
            {
                logger?.LogInformation("Finding fromUser");
                var fromUser = await GetUserByIdAsync(fromUserId);
                if (fromUser.IsSuccess)
                {
                    logger?.LogInformation("found fromUser, finding toUser");
                    var toUser = await dbContext.Users.Where(u => toUserId == u.Id).Include(w => w.WorkoutPlan.Workouts)
                    .Include(w => w.WorkoutPlan).Include(f => f.Friends).FirstOrDefaultAsync();
                    if (toUser != null)
                    {
                        logger?.LogInformation("found fromUser, getting workout");
                        var workoutChallenge = await dbContext.Workouts.Where(w => w.Id == workoutId).Include(w => w.Exercises).FirstOrDefaultAsync();
                        if (workoutChallenge != null)
                        {
                            logger?.LogInformation("Found workout, getting request");
                            Challenge? pendingChallenge = await dbContext.Challenges.Where(
                                c => c.ToUser.Id == toUserId
                                && c.FromUser.Id == fromUserId
                                && c.Workout.Id == workoutChallenge.Id).FirstOrDefaultAsync();
                            if (pendingChallenge != null)
                            {
                                logger?.LogInformation("found request, rejecting it now");
                                dbContext.Challenges.Remove(pendingChallenge);

                                dbContext.SaveChanges();
                                logger?.LogInformation("Done");
                                return (true, pendingChallenge, null);
                            }
                            return (false, null, "pending challenge didn't got Accepted");
                        }
                        return (false, null, "workout not found");
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

        
    }
}
