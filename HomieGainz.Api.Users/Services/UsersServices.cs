using AutoMapper;
using HomieGainz.Api.Application.Interfaces;
using HomieGainz.ApplicationDb.Db.MealDb;
using HomieGainz.ApplicationDb.Db.UserDb;
using HomieGainz.ApplicationDb.Db.WorkoutDb;
using HomieGainz.ApplicationDb.Db;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NuGet.Protocol;

namespace HomieGainz.Api.Users.Services
{
    public class UsersServices : IUserService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ILogger<UsersServices> logger;

        public UsersServices(ApplicationDbContext dbContext, ILogger<UsersServices> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            SeedData();
        }

        public async Task<(bool IsSuccess, IEnumerable<User> Users, string ErrorMessage)> GetUsersAsync()
        {
            try
            {
                logger?.LogInformation("Querying users");
                var users = await this.dbContext.Users.ToListAsync();
                if(users != null && users.Any())
                {
                    logger?.LogInformation($"{users.Count} customer(s) found");
                    return (true, users, null);
                }
                return (false, null, "Not Found");
            }
            catch(Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, User User, string ErrorMessage)> GetUserByIdAsync(int id)
        {
            try
            {
                logger?.LogInformation("Querying user");
                var user = await this.dbContext.Users.Where(u => id == u.Id).Include(m => m.MealPlan).FirstOrDefaultAsync();
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

        public async Task<(bool IsSuccess, User User, string ErrorMessage)> GetUserAsync(string username)
        {
            try
            {
                logger?.LogInformation("Querying user");
                var user = await this.dbContext.Users.Where(u => username == u.Username).FirstOrDefaultAsync();
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
        public async Task<(bool IsSuccess, User User, string ErrorMessage)> CreateUserAsync(User newUser)
        {
            try
            {
                logger?.LogInformation("Creating user");
                if (newUser != null)
                {
                    await this.dbContext.AddAsync(newUser);
                    dbContext?.SaveChanges();
                    logger?.LogInformation("User created");
                    return (true, newUser, null);
                }

                return (false, null, "User not created");

            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
        public async Task<(bool IsSuccess, User User, string ErrorMessage)> UpdateUserAsync(User updatedUser)
        {
            try 
            {
                logger?.LogInformation("Finding user");
                var oldUser = await GetUserByIdAsync(updatedUser.Id);
                if(oldUser.IsSuccess)
                {
                    logger?.LogInformation("Found User, updating now");
                    oldUser.User.Username = updatedUser.Username;
                    oldUser.User.Password = updatedUser.Password;
                    oldUser.User.Weight = updatedUser.Weight;
                    oldUser.User.Height = updatedUser.Height;
                    oldUser.User.MealPlan = updatedUser.MealPlan;
                    oldUser.User.WorkoutPlan = updatedUser.WorkoutPlan;
                    dbContext?.SaveChanges();
                    logger?.LogInformation("User updated");
                    return (true, updatedUser, null);
                }
                return (false, null, "User not Found");
            }
            catch(Exception ex) 
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
        public async Task<(bool IsSuccess, User User, string ErrorMessage)> DeleteUserAsync(int id)
        {
            try
            {
                logger?.LogInformation("Finding user");
                var user = await GetUserByIdAsync(id);
                if (user.IsSuccess)
                {
                    logger?.LogInformation("Found User, deleting now");
                    this.dbContext.Remove(user.User);
                    dbContext?.SaveChanges();
                    logger?.LogInformation("User deleted");
                    return (true, null, null);
                }
                return (false, null, "User not found");
            }
            catch(Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }



        public async Task<(bool IsSuccess, User User, string ErrorMessage)> GetQuestionaireTotalAsync(User user, int total)
        {
            try
            {
                    switch (total)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                            logger?.LogInformation("Slim down WorkoutPlan getting added to the user");
                            user.WorkoutPlan = await dbContext.WorkoutPlans.Where(w => w.Id == 3).FirstOrDefaultAsync();
                            logger?.LogInformation("Workout Plan added");

                            logger?.LogInformation("Low calories MealPlan getting added to the user");
                            user.MealPlan = await dbContext.MealPlans.Where(m => m.Id == 1).FirstOrDefaultAsync();
                            logger?.LogInformation("Meal Plan added");
                            break;
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                            logger?.LogInformation("Tune up WorkoutPlan getting added to the user");
                            user.WorkoutPlan = await dbContext.WorkoutPlans.Where(w => w.Id == 2).FirstOrDefaultAsync();
                            logger?.LogInformation("Workout Plan added");

                            logger?.LogInformation("Cut MealPlan getting added to the user");
                            user.MealPlan = await dbContext.MealPlans.Where(m => m.Id == 3).FirstOrDefaultAsync();
                            logger?.LogInformation("Meal Plan added");
                            break;
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                            logger?.LogInformation("Bulk up WorkoutPlan getting added to the user");
                            WorkoutPlan bulkUpPlan = await dbContext.WorkoutPlans.Where(w => w.Id == 1).FirstOrDefaultAsync();
                            user.WorkoutPlan = bulkUpPlan;
                            logger?.LogInformation("Workout Plan added");

                            logger?.LogInformation("High calories MealPlan getting added to the user");
                            MealPlan HighCaloriesPlan = await dbContext.MealPlans.Where(m => m.Id == 2).FirstOrDefaultAsync();
                            user.MealPlan = HighCaloriesPlan;
                            logger?.LogInformation("Meal Plan added");

                            break;
                    }
                    dbContext?.SaveChanges();
                    
                    return (true, user, null);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
        public async Task<(bool IsSuccess, User User, string ErrorMessage)> ChangeMealPlanAsync(User user, int mealPlanId)
        {
            try
            {
                    logger?.LogInformation("found user, getting mealplan");
                    var mealPlan = await dbContext.MealPlans.Where(m => m.Id == mealPlanId).FirstOrDefaultAsync();

                    logger?.LogInformation("found mealPlan, changing now");
                    user.MealPlan = mealPlan;

                    logger?.LogInformation($"mealplan added to user {user.MealPlan}");
                    dbContext?.SaveChanges();
                    return (true, user, null);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
        public async Task<(bool IsSuccess, User User, string ErrorMessage)> ChangeWorkoutPlanAsync(User user, int workoutPlanId)
        {
            try
            {
                logger?.LogInformation("found user, getting workoutplan");
                var workoutPlan = await dbContext.WorkoutPlans.Where(m => m.Id == workoutPlanId).FirstOrDefaultAsync();

                logger?.LogInformation("found workoutPlan, changing now");
                user.WorkoutPlan = workoutPlan;

                logger?.LogInformation($"workoutplan added to user {user.WorkoutPlan}");
                dbContext?.SaveChanges();
                return (true, user, null);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
        private void SeedData()
        {
            var mealPlan = dbContext.MealPlans.Where(m => m.Id == 1).Include(m => m.Meals).FirstOrDefault();
            var meal = dbContext.Meals.Where(m => m.Id == 1).FirstOrDefault();
            mealPlan.Meals.Add(meal);
           
            this.dbContext.SaveChanges();
        }

    }
}
