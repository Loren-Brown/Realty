using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Realty.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Realty.Controllers
{
    [Authorize]
    public class ManagePropertiesController : Controller
    {
        private readonly RealtyContext _context;
        private UserManager<ApplicationUser> _userManager;

        public ManagePropertiesController(RealtyContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: ManageProperties
        public async Task<IActionResult> Index()
        {
            string userId = _userManager.GetUserId(User);
            var properties = from p in _context.Property
                             where p.OwnerId == userId
                            select p;

            return View(await properties.ToListAsync());
        }

        // GET: ManageProperties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = await _context.Property
                .SingleOrDefaultAsync(m => m.ID == id);
            if (@property == null)
            {
                return NotFound();
            }

            return View(@property);
        }

        // GET: ManageProperties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ManageProperties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Street1,Street2,City,State,ZipCode,Neighborhood,SalesPrice,DateListed,Bedrooms,Bathrooms,GarageSize,SquareFeet,LotSize,Description")] Property @property)
        {
            if (ModelState.IsValid)
            {
                property.OwnerId = _userManager.GetUserId(User);
                _context.Add(@property);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@property);
        }

        // GET: ManageProperties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = await _context.Property.SingleOrDefaultAsync(m => m.ID == id);
            if (@property == null)
            {
                return NotFound();
            }
            return View(@property);
        }

        // POST: ManageProperties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Street1,Street2,City,State,ZipCode,Neighborhood,SalesPrice,DateListed,Bedrooms,Bathrooms,GarageSize,SquareFeet,LotSize,Description")] Property @property)
        {
            if (id != @property.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@property);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyExists(@property.ID))
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
            return View(@property);
        }

        // GET: ManageProperties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = await _context.Property
                .SingleOrDefaultAsync(m => m.ID == id);
            if (@property == null)
            {
                return NotFound();
            }

            return View(@property);
        }

        // POST: ManageProperties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @property = await _context.Property.SingleOrDefaultAsync(m => m.ID == id);
            _context.Property.Remove(@property);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyExists(int id)
        {
            return _context.Property.Any(e => e.ID == id);
        }
    }
}
