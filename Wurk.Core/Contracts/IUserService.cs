namespace Wurk.Core.Contracts
{ 
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Wurk.Core.Models.Administrator;
    using Wurk.Core.Models.Users;
    using Wurk.Infrastructure.Data.Models;

    public interface IUserService
    {
        IEnumerable<UserViewModel> GetAllUser(string userId);

        Task<ApplicationUser> GetUserById(string userId);

        Task<T> GetUser<T>(string userId);

        Task<ApplicationUser> GetApplicationUser<T>(string userId);

        Task<UserEditViewModel> GetUserToEdit(string userId);

        Task<IEnumerable<UserListViewModel>> GetUsers();

        Task<bool> UpdateUser(UserEditViewModel model);

        string GetIdByUsername(UserViewModel model);

        Task<string> UpdateProfile(string userId, ProfileViewModel model);

        string GetUrl(string userId);

        Task<string> DeleteAsync(string userId);
    }
}
