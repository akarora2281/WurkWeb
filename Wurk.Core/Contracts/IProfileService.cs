namespace Wurk.Core.Contracts
{ 
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Wurk.Core.Models.Profile;
    using Wurk.Core.Models.Users;
    using Wurk.Infrastructure.Data.Models;

    public interface IProfileService
    {
        Task<bool> CreateProfileFeelGoodAsync(Profile_FeelGood model, string user);

        Task<bool> CreateProfileDoGoodAsync(Profile_DoGood model, string user);

        Task<bool> CreateProfileBeGoodAsync(Profile_BeGood model, string user);

        Task<bool> CreateProfileAsync(ProfileCreateInputModel model);
    }
}
