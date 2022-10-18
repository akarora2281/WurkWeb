using Wurk.Core.Models.Administrator;
using Wurk.Core.Models.FaqEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wurk.Core.Contracts
{
    public interface IAboutService
    {
        Task<FaqViewModel> CreateAsync(FaqCreateInputViewModel model);

        Task EditAsync(FaqEditViewModel model);

        Task DeleteById(int faqId);

        Task<IEnumerable<FaqViewModel>> GetAllFaqsAsync<T>();

        Task<FaqViewModel> GetByIdAsync<T>(int faqId);

    }
}
