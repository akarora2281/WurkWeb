namespace Wurk.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using Wurk.Core.Contracts;
    using Wurk.Core.Mapping;
    using Wurk.Core.Models.Administrator;
    using Wurk.Core.Models.Users;
    using Wurk.Infrastructure.Data;
    using Wurk.Infrastructure.Data.Models;
    using Wurk.Infrastructure.Data.Repositories;
    using Microsoft.EntityFrameworkCore;
    using static Wurk.Common.MessageConstants;

    public class UserService : IUserService
    {
        private readonly IAppRepository _userRepo;
        private readonly ApplicationDbContext _applicationDbContext;


        public UserService(IAppRepository userRepo, ApplicationDbContext applicationDbContext)
        {
            this._userRepo = userRepo;
            this._applicationDbContext = applicationDbContext;
        }

        public IEnumerable<UserViewModel> GetAllUser(string userId)
        {
            return this._userRepo
                .All<UserViewModel>()
                .Where(u => u.UserId == userId)
                .ToList();
        }

        public async Task<ApplicationUser> GetUserById(string userId)
        {
            //  return await this.userRepo.GetByIdAsync<ApplicationUser>(userId);

            return await _applicationDbContext.ArtGalleryUser.Where(x => x.Id == userId).Select(x => new ApplicationUser()
            {
                Id = x.Id,
                AccessFailedCount = x.AccessFailedCount,
                CreatedOn = x.CreatedOn,
                Email = x.Email,
                EmailConfirmed = x.EmailConfirmed,
                FirstName = x.FirstName,
                LastName = x.LastName,
                LockoutEnabled = x.LockoutEnabled,
                Roles = x.Roles,
                UserName = x.UserName,
            })
            .FirstOrDefaultAsync();
        }

        public Task<T> GetUser<T>(string userId)
        {
            var user = this._userRepo.All<ApplicationUser>()
                .Where(u => u.Id == userId)
                .To<ProfileViewModel>()
                .FirstOrDefault();

            if (user == null)
            {
                throw new ArgumentNullException(string.Format(nameof(user)));
            }

            var userModel = AutoMapperConfig.MapperInstance.Map<T>(user);

            return Task.FromResult(userModel);
        }

        public Task<ApplicationUser> GetApplicationUser<T>(string userId)
        {
            var user = this._userRepo.All<ApplicationUser>()
                .Where(u => u.Id == userId)
                .FirstOrDefault();

            return Task.FromResult(user);
        }

        public string GetIdByUsername(UserViewModel model)
        {
            var user = this._userRepo
                .All<ArtGalleryUser>()
                .SingleOrDefault(x => x.UserName == model.UserName);

            if (user == null)
            {
                throw new ArgumentNullException(string.Format(InvalidUsername, model.UserName));
            }

            return user.Id;
        }

        public async Task<IEnumerable<UserListViewModel>> GetUsers()
        {
            /*return await _applicationDbContext.ArtGalleryUser.Select(u => new UserListViewModel()
            {
                Email = u.Email,
                UserName = u.UserName,
                Id = u.Id,
                Name = $"{u.FirstName} {u.LastName}",
            })
                                 .ToListAsync();*/

            return this._userRepo.All<ApplicationUser>()
                                 .Select(u => new UserListViewModel()
                                 {
                                     Email = u.Email,
                                     UserName = u.UserName,
                                    Id = u.Id,
                                     Name = $"{u.FirstName} {u.LastName}",
                                 })
                                 .ToList();
        }

        public async Task<UserEditViewModel> GetUserToEdit(string userId)
        {
            var user = await this._userRepo.GetByIdAsync<ArtGalleryUser>(userId);

            return new UserEditViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
        }

        public async Task<bool> UpdateUser(UserEditViewModel model)
        {
            bool result = false;
            var user = await this._userRepo
                .GetByIdAsync<ArtGalleryUser>(model.Id);

            if (user != null)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;

                await this._userRepo.SaveChangesAsync();
                result = true;
            }

            return result;
        }

        public async Task<string> UpdateProfile(string userId, ProfileViewModel model)
        {
            var user = this._userRepo.AllReadonly<ArtGalleryUser>().FirstOrDefault(u => u.Id == userId);

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            user.FirstName = model.FirstName;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            user.LastName = model.LastName;
            user.UserName = model.UserName;
            user.Gender = model.Gender;
            user.UrlImage = model.UrlImage;
            user.Email = model.Email;

            this._userRepo.Update(user);
            await this._userRepo.SaveChangesAsync();

            return user.Id;
        }

        public string GetUrl(string userId)
        {
            var user = this._userRepo.All<ArtGalleryUser>()
                .FirstOrDefault(u => u.Id == userId);
            var url = user.UrlImage;
            return url;
        }

        public async Task<string> DeleteAsync(string userId)
        {
            var currentUser = await this._userRepo
                .AllWithDeleted<ArtGalleryUser>()
                .Where(u => u.Id == userId)
                .Include(u => u.UrlImage)
                .SingleOrDefaultAsync();

            var id = currentUser?.Id ?? string.Empty;

            if (id == " ")
            {
                id = string.Empty;
            }

            return id;
        }
    }
}
