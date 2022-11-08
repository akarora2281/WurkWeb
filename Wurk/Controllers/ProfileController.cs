using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wurk.Core.Models.Profile;
using Wurk.Infrastructure.Data;
using Wurk.Infrastructure.Data.Models;

namespace Wurk.Controllers
{
    //[Authorize(Roles = GlobalConstants.UserRoleName)]
    //[Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IProfileService _profile;

        public ProfileController(ApplicationDbContext context, IProfileService profile)
        {
            _context = context;
            _profile = profile;
        }

        // GET: Profile
        public async Task<IActionResult> Index()
        {
            return View(await _context.Profile_Questions.ToListAsync());
        }

        // GET: Profile/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile_Questions = await _context.Profile_Questions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profile_Questions == null)
            {
                return NotFound();
            }

            return View(profile_Questions);
        }

        // GET: Profile/Create
        public IActionResult Create()
        {
            ProfileCreateInputModel model = new ProfileCreateInputModel();

            model.UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View(model);
        }

        // POST: Profile/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("UserId,QuestionCategory,Question,Answer,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] ProfileCreateInputModel model)
        public async Task<IActionResult> Create(ProfileCreateInputModel model)
        {
            if (ModelState.IsValid)
            {
                await _profile.CreateProfileAsync(model);

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Profile/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile_Questions = await _context.Profile_Questions.FindAsync(id);
            if (profile_Questions == null)
            {
                return NotFound();
            }
            return View(profile_Questions);
        }

        // POST: Profile/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,QuestionCategory,Question,Answer,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Profile_Questions profile_Questions)
        {
            if (id != profile_Questions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profile_Questions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Profile_QuestionsExists(profile_Questions.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(profile_Questions);
        }

        // GET: Profile/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile_Questions = await _context.Profile_Questions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profile_Questions == null)
            {
                return NotFound();
            }

            return View(profile_Questions);
        }

        // POST: Profile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profile_Questions = await _context.Profile_Questions.FindAsync(id);
            _context.Profile_Questions.Remove(profile_Questions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Profile_QuestionsExists(int id)
        {
            return _context.Profile_Questions.Any(e => e.Id == id);
        }
    }
}
