using AutoMapper;
using HomieGainz.Api.Application.Interfaces;
using HomieGainz.ApplicationDb.Db.MealDb;
using HomieGainz.ApplicationDb.Db.UserDb;
using HomieGainz.ApplicationDb.Db.WorkoutDb;
using HomieGainz.UserMeals.Db;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                var user = await this.dbContext.Users.Where(u => id == u.Id).FirstOrDefaultAsync();
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

        public async Task<(bool IsSuccess, User User, string ErrorMessage)> GetUserAsync(string username, string password)
        {
            try
            {
                logger?.LogInformation("Querying user");
                var user = await this.dbContext.Users.Where(u => username == u.Username && u.Password == password).FirstOrDefaultAsync();
                if (user != null && user.Password.Equals(password))
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

        private void SeedData()
        {
            if (!dbContext.Users.Any())
            {
                dbContext.Users.Add(new User() { Username = "Scipion2002", Password = "TestPass", Age = 19, Weight = 164, Height = 6.1, WorkoutPlan =  new WorkoutPlan() { Name = "Move", Description = "ur mooom"} });
                dbContext.Users.Add(new User() { Username = "DNgo-Neumont", Password = "DavidPass", Age = 20, Weight = 156, Height = 6 });
                dbContext.Users.Add(new User() { Username = "Rxittles", Password = "RobPass", Age = 21, Weight = 135, Height = 6 });
                dbContext.SaveChanges();
            }
        }

        
    }
}
