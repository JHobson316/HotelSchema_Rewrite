using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelSchema_Rewrite.Data;
using HotelSchema_Rewrite.Models;
using HotelSchema_Rewrite.Models.DTO;
using System.Diagnostics.Eventing.Reader;
using System.Web.Http.Description;
//using System.Web.Http;
using HotelSchemaRewrite.Migrations;

namespace HotelSchema_Rewrite.Controllers.Web
{
    //[Route("[controller]")]
    public class AmenitiesController : Controller
    {
        private readonly TestDbContext _context;

        public AmenitiesController(TestDbContext context)
        {
            _context = context;
        }

        // GET: Amenities
        public IQueryable<AmenityDto> GetAmenities()
        {
            var Amenities = from a in _context.Amenities
                            select new AmenityDto()
                            {
                                Name = a.Name
                            };
            return Amenities;
        }

        // GET: Amenities/Details/5
        [ResponseType(typeof(AmenityDetailDto))]
        public async Task<ActionResult> GetAmenity(int id)
        {
            var Amenity = await _context.Amenities.Include(a => a.Name).Select( a =>
                new AmenityDetailDto()
                {
                    ID = a.ID,
                    Name = a.Name
                }).SingleOrDefaultAsync(a =>a.ID == id);
            if (Amenity == null)
            {
                return NotFound();
            }
            return Ok(Amenity);
        }

        // GET: Amenities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Amenities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        [ResponseType(typeof(AmenityDto))]
        public async Task<ActionResult> PostAmenity(Amenity amenity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.Amenities.Add(amenity);

            //_context.Entry(amenity).Reference(x => x.Name).Load;
            await _context.SaveChangesAsync();
            var dto = new AmenityDto()
            {
                Name = amenity.Name,
                ID = amenity.ID
            };

            return RedirectToAction(nameof(Index));
        }

        // GET: Amenities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Amenities == null)
            {
                return NotFound();
            }

            var amenity = await _context.Amenities.FindAsync(id);
            if (amenity == null)
            {
                return NotFound();
            }
            return View(amenity);
        }

        // POST: Amenities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Amenity amenity)
        {
            if (id != amenity.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(amenity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmenityExists(amenity.ID))
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
            return View(amenity);
        }

        // GET: Amenities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Amenities == null)
            {
                return NotFound();
            }

            var amenity = await _context.Amenities
                .FirstOrDefaultAsync(m => m.ID == id);
            if (amenity == null)
            {
                return NotFound();
            }

            return View(amenity);
        }

        // POST: Amenities/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Amenities == null)
            {
                return Problem("Entity set 'TestDbContext.Amenities'  is null.");
            }
            var amenity = await _context.Amenities.FindAsync(id);
            if (amenity != null)
            {
                _context.Amenities.Remove(amenity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AmenityExists(int id)
        {
          return _context.Amenities.Any(e => e.ID == id);
        }
    }
}
