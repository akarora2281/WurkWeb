namespace Wurk.Core.Services
{
    using Wurk.Common;
    using Wurk.Core.Contracts;
    using Wurk.Core.Mapping;
    using Wurk.Core.Models.Administrator;
    using Wurk.Core.Models.FaqEntity;
    using Wurk.Infrastructure.Data;
    using Wurk.Infrastructure.Data.Models;
    using Wurk.Infrastructure.Data.Repositories;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FaqEntity = Infrastructure.Data.Models.FaqEntity;

    // Code change by bhavin.
    public class AboutService : IAboutService
    {
        private readonly IAppRepository _faqRepo;
        private readonly ApplicationDbContext _applicationDbContext;

        public AboutService(IAppRepository faqRepo, ApplicationDbContext _applicationDbContext)
        {
            this._faqRepo = faqRepo;
            this._applicationDbContext = _applicationDbContext;
        }

        public async Task<FaqViewModel> CreateAsync(FaqCreateInputViewModel model)
        {
            var faq = new FaqViewModel
            {
                Question = model.Question,
                Answer = model.Answer,
            };
            // Code change by behaviour.
            //bool isExist = await _faqRepo.All<FaqViewModel>()
            //    .AnyAsync(x => x.Question == model.Question && x.Answer == model.Answer);

            bool isExist = await _applicationDbContext.Faqs
                .Where(x => x.Question == model.Question && x.Answer == model.Answer)
                .AnyAsync();

            if (isExist)
            {
                throw new ArgumentException(string.Format(MessageConstants.FaqAlreadyExist, model.Question, model.Answer));
            }

            //await _faqRepo.AddAsync(faq);
            //await _faqRepo.SaveChangesAsync();

            var faq1 = await _applicationDbContext.Faqs.AddAsync(new FaqEntity()
            {
                Answer = model.Answer,
                Question = model.Question,
                CreatedOn = DateTime.Now,
                IsDeleted = false
            });


            _applicationDbContext.SaveChanges();

            //  var viewModel = await this.GetByIdAsync<FaqViewModel>(faq.FaqId);

            // return viewModel;

            return new FaqViewModel();
        }

        public async Task DeleteById(int faqId)
        {
            // var faq = _faqRepo.All<FaqEntity>().FirstOrDefault(x => x.Id == faqId);
            var faq = _applicationDbContext.Faqs.FirstOrDefault(x => x.Id == faqId);

            if (faq == null)
            {
                throw new ArgumentNullException(string.Format(MessageConstants.FaqNotFound, faqId));
            }

            faq.IsDeleted = true;
            faq.DeletedOn = DateTime.UtcNow;
            //_faqRepo.Update(faq);
            //_faqRepo.SaveChanges();

            _applicationDbContext.Faqs.Update(faq);
            _applicationDbContext.SaveChanges();
        }

        public async Task EditAsync(FaqEditViewModel model)
        {
            // var faq = _faqRepo.All<FaqEntity>().FirstOrDefault(x => x.Id == model.FaqId);
            var faq = _applicationDbContext.Faqs.FirstOrDefault(x => x.Id == model.FaqId);

            if (faq == null)
            {
                throw new ArgumentNullException(string.Format(MessageConstants.FaqNotFound, model.FaqId));
            }

            faq.Answer = model.Answer;
            faq.Question = model.Question;
            faq.ModifiedOn = DateTime.UtcNow;

            //_faqRepo.Update(faq);
            //_faqRepo.SaveChanges();

            _applicationDbContext.Faqs.Update(faq);
            _applicationDbContext.SaveChanges();
        }

        public async Task<IEnumerable<FaqViewModel>> GetAllFaqsAsync<T>()
        {

            var result = await _applicationDbContext.Faqs.Select(x => new FaqViewModel
            {
                Answer = x.Answer,
                FaqId = x.Id,
                Question = x.Question
            }).ToListAsync();

            return result;
        }

        public async Task<FaqViewModel> GetByIdAsync<T>(int faqId)
        {
            //var faqModel = _faqRepo
            //    .All<FaqViewModel>()
            //    .Where(f => f.FaqId == faqId)
            //    .To<T>()
            //    .FirstOrDefault();

            var faqModel = _applicationDbContext
              .Faqs
              .Where(f => f.Id == faqId)
              .Select(x => new FaqViewModel()
              {
                  Answer = x.Answer,
                  FaqId = x.Id,
                  Question = x.Question
              })
              .FirstOrDefault();

            return faqModel;
        }
    }
}

