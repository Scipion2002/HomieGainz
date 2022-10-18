using AutoMapper;
using HomieGainz.Api.Application.Interfaces;
using HomieGainz.ApplicationDb.Db.MealDb;
using HomieGainz.ApplicationDb.Db.UserDb;
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
                logger?.LogInformation("Querying users");
                var user = await this.dbContext.Users.Where(u => id == u.Id).FirstOrDefaultAsync();
                if (user != null)
                {
                    logger?.LogInformation("Customer found");
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
                    logger?.LogInformation("Customer found");
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
        public async Task<(bool IsSuccess, User User, string ErrorMessage)> CreateUserAsync(User user)
        {
            try
            {
                logger?.LogInformation("Creating user");
                if (user != null)
                {
                    await this.dbContext.AddAsync(user);
                    dbContext.SaveChanges();
                    logger?.LogInformation("Customer created");
                    return (true, user, null);
                }

                return (false, null, "user not created");

            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        private void SeedData()
        {
            if (!dbContext.Users.Any())
            {
                dbContext.Users.Add(new User() { Username = "Scipion2002", Password = "TestPass", Age = 19, Weight = 164, Height = 6.1 });
                dbContext.Users.Add(new User() { Username = "DNgo-Neumont", Password = "DavidPass", Age = 20, Weight = 156, Height = 6 });
                dbContext.Users.Add(new User() { Username = "Rxittles", Password = "RobPass", Age = 21, Weight = 135, Height = 6 });
                dbContext.SaveChanges();
            }
        }

        
    }
}
