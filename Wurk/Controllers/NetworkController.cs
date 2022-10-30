#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wurk.Core.Models.Administrator;
using Wurk.Core.Models.Network;
using Wurk.Infrastructure.Data;
using Wurk.Infrastructure.Data.Models;

namespace Wurk.Controllers
{
    public class NetworkController : Controller
    {
        private readonly INetworkService _network;

        public NetworkController(INetworkService network)
        {
            _network = network;
        }

        // GET: Network
        public async Task<IActionResult> Index()
        {
            var modelView = this._network.GetAll();

            var allNetworks = modelView.Select(e => new AllNetworkListViewModel
            {
                Title = e.Title,
                UserId = e.UserId,
                Tags = e.Tags,
                Description = e.Description,
            }).ToList();

            return View(allNetworks);
        }

        // GET: Network/Details/5
        /*public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var network = await _network.Networks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (network == null)
            {
                return NotFound();
            }

            return View(network);
        }*/

        // GET: Network/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Network/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,Tags,EmployerId")] Network network)
        {
            var networkCreateInputModel = new NetworkCreateInputModel();

            networkCreateInputModel.Title = network.Title;
            networkCreateInputModel.Description = network.Description;
            networkCreateInputModel.Tags = network.Tags;


            if (ModelState.IsValid)
            {
                await _network.CreateNetworkAsync(networkCreateInputModel, network.UserId);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(network);
        }

        // GET: Network/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = new NetworkEditViewModel();

            var network = await _network.EditNetwork(model, id.Value);

            return View(network);
        }

        // POST: Network/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Description,Tags,UserId,EmployerId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] NetworkEditViewModel network)
        {
            if (id != network.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _network.EditNetwork(network, network.Id);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NetworkExists(network.Id))
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
            return View(network);
        }

        // GET: Network/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _network..Delete(id.Value);
            if (network == null)
            {
                return NotFound();
            }

            return View(network);
        }

        // POST: Network/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var network = await _context.Networks.FindAsync(id);
            _context.Networks.Remove(network);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NetworkExists(int id)
        {
            return _context.Networks.Any(e => e.Id == id);
        }*/
    }
}
