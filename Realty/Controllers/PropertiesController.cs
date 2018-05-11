using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Realty.Models;

namespace Realty.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly RealtyContext _context;

        public PropertiesController(RealtyContext context)
        {
            _context = context;
        }

        // GET: Properties
        public async Task<IActionResult> Index(string mlsSearch, string citySearch, string stateSearch, string zipSearch, string bedroomSearch, string bathroomSearch, string squareFeetSearch)
        {
            var properties = from p in _context.Property
                         select p;

            if (!String.IsNullOrEmpty(mlsSearch))
            {
                properties = properties.Where(s => s.ID.Equals(Convert.ToInt32(mlsSearch)));
            }
            if (!String.IsNullOrEmpty(citySearch))
            {
                properties = properties.Where(s => s.City.Contains(citySearch));
            }
            if (!String.IsNullOrEmpty(stateSearch))
            {
                properties = properties.Where(s => s.State.Contains(stateSearch));
            }
            if (!String.IsNullOrEmpty(zipSearch))
            {
                properties = properties.Where(s => s.ZipCode.Equals(Convert.ToInt32(zipSearch)));
            }
            if (!String.IsNullOrEmpty(bedroomSearch))
            {
                properties = properties.Where(s => s.Bedrooms.Equals(Convert.ToInt32(bedroomSearch)));
            }
            if (!String.IsNullOrEmpty(bathroomSearch))
            {
                properties = properties.Where(s => s.Bathrooms.Equals(Convert.ToInt32(bathroomSearch)));
            }
            if (!String.IsNullOrEmpty(squareFeetSearch))
            {
                properties = properties.Where(s => s.SquareFeet.Equals(Convert.ToInt32(squareFeetSearch)));
            }

            return View(await properties.ToListAsync());
        }

        // GET: Properties/Details/5
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
    }
}
