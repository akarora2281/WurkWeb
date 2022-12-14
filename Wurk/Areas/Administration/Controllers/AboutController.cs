using Wurk.Core.Models.Administrator;
using Wurk.Core.Models.FaqEntity;
using Microsoft.AspNetCore.Mvc;
using FaqEntity = Wurk.Infrastructure.Data.Models.FaqEntity;

namespace Wurk.Areas.Administration.Controllers
{
    public class AboutController : AdministrationController
    {
        private readonly IAboutService aboutService;

        public AboutController(IAboutService aboutService)
        {
            this.aboutService = aboutService;
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FaqCreateInputViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            await this.aboutService.CreateAsync(model);
            return this.RedirectToAction("All", "About", new { area = "Administration" });
        }

        [HttpGet("Administration/About/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var faqToEdit = await this.aboutService.GetByIdAsync<FaqEntity>(id);
            var _model = new FaqEditViewModel();
            _model.FaqId = faqToEdit.FaqId;
            _model.Answer = faqToEdit.Answer;
            _model.Question = faqToEdit.Question;
            return View(_model);
        }

        [HttpPost("Administration/About/Edit")]
        public async Task<IActionResult> Edit(FaqEditViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.aboutService.EditAsync(model);
            return RedirectToAction("All", "About", new { area = "Administration" });
        }

        public async Task<IActionResult> All()
        {
            var faq = await this.aboutService.GetAllFaqsAsync<FaqViewModel>();
            ViewBag.faq = faq.ToList();
            return View();
        }
    }
}
