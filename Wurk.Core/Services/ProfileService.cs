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
    using Wurk.Core.Models.Profile;
    using Wurk.Core.Models.Users;
    using Wurk.Infrastructure.Data;
    using Wurk.Infrastructure.Data.Models;
    using Wurk.Infrastructure.Data.Repositories;
    using Microsoft.EntityFrameworkCore;
    using static Wurk.Common.MessageConstants;
    using AutoMapper;
    using Wurk.Infrastructure.Data.Models.Enumeration;

    public class ProfileService : IProfileService
    {
        private readonly IAppRepository _profileRepo;


        public ProfileService(IAppRepository profileRepo)
        {
            this._profileRepo = profileRepo;
        }

        public async Task<bool> CreateProfileAsync(ProfileCreateInputModel model)
        {
            List<Profile_Questions> profile = new List<Profile_Questions>();

            //DoGood attributes
            profile.Add(new Profile_Questions { UserId = model.UserId, QuestionCategory = Questions_Category.DoGood, Question = "DoGood_People", Answer = model.doGood.People });
            profile.Add(new Profile_Questions { UserId = model.UserId, QuestionCategory = Questions_Category.DoGood, Question = "DoGood_Planet", Answer = model.doGood.Planet });
            profile.Add(new Profile_Questions { UserId = model.UserId, QuestionCategory = Questions_Category.DoGood, Question = "DoGood_Prosperity", Answer = model.doGood.Prosperity });

            //BeGood attributes

            profile.Add(new Profile_Questions { UserId = model.UserId, QuestionCategory = Questions_Category.BeGood, Question = "BeGood_Action", Answer = model.beGood.Action });
            profile.Add(new Profile_Questions { UserId = model.UserId, QuestionCategory = Questions_Category.BeGood, Question = "BeGood_Action", Answer = model.beGood.Knowledge });
            profile.Add(new Profile_Questions { UserId = model.UserId, QuestionCategory = Questions_Category.BeGood, Question = "BeGood_Action", Answer = model.beGood.Passions });

            // Feel Good attributes
            profile.Add(new Profile_Questions { UserId = model.UserId, QuestionCategory = Questions_Category.FeelGood, Question = "FeelGood_Knowledge", Answer = model.feelGood.Knowledge });
            profile.Add(new Profile_Questions { UserId = model.UserId, QuestionCategory = Questions_Category.FeelGood, Question = "FeelGood_Passions", Answer = model.feelGood.Passions });
            profile.Add(new Profile_Questions { UserId = model.UserId, QuestionCategory = Questions_Category.FeelGood, Question = "FeelGood_Talents", Answer = model.feelGood.Talents });

            await this._profileRepo.AddRangeAsync(profile);
            await this._profileRepo.SaveChangesAsync();

            return true;
        }

        public async Task<bool> CreateProfileDoGoodAsync(Profile_DoGood model, string user)
        {
            bool isProfileExist = this._profileRepo.All<Profile_Questions>().Any(x => (x.UserId == user && x.QuestionCategory == Questions_Category.DoGood));

            if (isProfileExist)
            {
                throw new ArgumentException(string.Format(ProfileDoGoodAlreadyExists, user));
            }

            List<Profile_Questions> profile_DoGood = new List<Profile_Questions>();

            profile_DoGood.Add(new Profile_Questions { UserId = user, QuestionCategory = Questions_Category.DoGood, Question = "DoGood_People", Answer = model.People });
            profile_DoGood.Add(new Profile_Questions { UserId = user, QuestionCategory = Questions_Category.DoGood, Question = "DoGood_Planet", Answer = model.Planet });
            profile_DoGood.Add(new Profile_Questions { UserId = user, QuestionCategory = Questions_Category.DoGood, Question = "DoGood_Prosperity", Answer = model.Prosperity });

            await this._profileRepo.AddRangeAsync(profile_DoGood);
            await this._profileRepo.SaveChangesAsync();

            return true;
        }

        public async Task<bool> CreateProfileBeGoodAsync(Profile_BeGood model, string user)
        {
            bool isProfileExist = this._profileRepo.All<Profile_Questions>().Any(x => (x.UserId == user && x.QuestionCategory == Questions_Category.BeGood));

            if (isProfileExist)
            {
                throw new ArgumentException(string.Format(ProfileBeGoodAlreadyExists, user));
            }

            List<Profile_Questions> profile_BeGood = new List<Profile_Questions>();

            profile_BeGood.Add(new Profile_Questions { UserId = user, QuestionCategory = Questions_Category.BeGood, Question = "BeGood_Action" , Answer = model.Action });
            profile_BeGood.Add(new Profile_Questions { UserId = user, QuestionCategory = Questions_Category.BeGood, Question = "BeGood_Action", Answer = model.Knowledge });
            profile_BeGood.Add(new Profile_Questions { UserId = user, QuestionCategory = Questions_Category.BeGood, Question = "BeGood_Action", Answer = model.Passions });

            await this._profileRepo.AddRangeAsync(profile_BeGood);
            await this._profileRepo.SaveChangesAsync();

            return true;
        }

        public async Task<bool> CreateProfileFeelGoodAsync(Profile_FeelGood model, string user)
        {
            bool isProfileExist = this._profileRepo.All<Profile_Questions>().Any(x => (x.UserId == user && x.QuestionCategory == Questions_Category.FeelGood));

            if (isProfileExist)
            {
                throw new ArgumentException(string.Format(ProfileBeGoodAlreadyExists, user));
            }

            List<Profile_Questions> profile_FeelGood = new List<Profile_Questions>();

            profile_FeelGood.Add(new Profile_Questions { UserId = user, QuestionCategory = Questions_Category.FeelGood, Question = "FeelGood_Knowledge", Answer = model.Knowledge });
            profile_FeelGood.Add(new Profile_Questions { UserId = user, QuestionCategory = Questions_Category.FeelGood, Question = "FeelGood_Passions", Answer = model.Passions });
            profile_FeelGood.Add(new Profile_Questions { UserId = user, QuestionCategory = Questions_Category.FeelGood, Question = "FeelGood_Talents", Answer = model.Talents });

            await this._profileRepo.AddRangeAsync(profile_FeelGood);
            await this._profileRepo.SaveChangesAsync();

            return true;
        }
    }
}
