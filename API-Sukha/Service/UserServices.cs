﻿using API_Sukha.IServices;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;
using Logic.Logic;
using Resource.RequestModels;

namespace API_Sukha.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserLogic _userLogic;
        public UserServices(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }
        public async Task<int> InsertUserAsync(UserItem userItem)
        {
            //var newUserItem = newUserRequest.ToUserItem();
            return await _userLogic.InsertUserAsync(userItem);
        }
        public async Task<List<UserItem>> GetAllUsersAsync()
        {
            return await _userLogic.GetAllUsersAsync();
        }
        public async Task<UserItem> GetUserByIdAsync(int id)
        {
            return await _userLogic.GetUserByIdAsync(id);
        }
        public async Task<List<UserItem>> GetUsersByCriteriaAsync(UserFilter userFilter)
        {
            return await _userLogic.GetUsersByCriteriaAsync(userFilter);
        }

        public async Task UpdateUserAsync(UserItem userItem)
        {
            await _userLogic.UpdateUserAsync(userItem);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userLogic.DeleteUserAsync(id);
        }
    }
}
