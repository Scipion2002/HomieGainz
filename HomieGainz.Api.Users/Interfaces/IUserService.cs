﻿
using HomieGainz.ApplicationDb.Db.UserDb;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomieGainz.Api.Application.Interfaces
{
    public interface IUserService
    {
        Task<(bool IsSuccess, IEnumerable<User> Users, string ErrorMessage)> GetUsersAsync();
        Task<(bool IsSuccess, User User, string ErrorMessage)> GetUserByIdAsync(int id);
        Task<(bool IsSuccess, User User, string ErrorMessage)> GetUserAsync(string username, string password);
        Task<(bool IsSuccess, User User, string ErrorMessage)> CreateUserAsync(User user);

    }
}
