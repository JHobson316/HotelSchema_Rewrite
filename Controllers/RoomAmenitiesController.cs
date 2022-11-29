using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelSchema_Rewrite.Data;
using HotelSchema_Rewrite.Models;
using HotelSchema_Rewrite.Models.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSchema_Lab12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomAmenitiesController : ControllerBase
    {
        private readonly IRoomAmenities _context;

        public RoomAmenitiesController(IRoomAmenity c)
        {
            _RoomAmenity = c;
        }

        // GET: api/RoomAmenities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomAmenity>>> GetRoomAmenities()
        {
            var list = await _RoomAmenity.GetRoomAmenities();
            return Ok(list);
        }
        //{
        //    return View(await _context.RoomAmenities.ToListAsync());
        //}

        // GET: RoomAmenities/Details/5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomAmenity>> GetRoomAmenity(int? id)
        {
            RoomAmenity RoomAmenity = await _RoomAmenity.GetRoomAmenity(id);
            return RoomAmenity;

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutRoomAmenity(int id, RoomAmenity roomAmenity)
        {
            if (id != roomAmenity.ID)
            {
                return BadRequest();
            }
            var updatedRoomAmenity = await _RoomAmenity.UpdateRoomAmenity(id, RoomAmenity);
            return Ok(updatedRoomAmenity);
        }
        //{
        //    if (id == null || _context.RoomAmenities == null)
        //    {
        //        return NotFound();
        //    }

        //    var roomAmenity = await _context.RoomAmenities
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (roomAmenity == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(roomAmenity);
        //}

        // GET: RoomAmenities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomAmenities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<RoomAmenity>> PostRoomAmenity(RoomAmenity roomAmenity)
    {

    }
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomAmenity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roomAmenity);
        }

        // GET: RoomAmenities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RoomAmenities == null)
            {
                return NotFound();
            }

            var roomAmenity = await _context.RoomAmenities.FindAsync(id);
            if (roomAmenity == null)
            {
                return NotFound();
            }
            return View(roomAmenity);
        }

        // POST: RoomAmenities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,RoomID")] RoomAmenity roomAmenity)
        {
            if (id != roomAmenity.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomAmenity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomAmenityExists(roomAmenity.ID))
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
            return View(roomAmenity);
        }

        // GET: RoomAmenities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RoomAmenities == null)
            {
                return NotFound();
            }

            var roomAmenity = await _context.RoomAmenities
                .FirstOrDefaultAsync(m => m.ID == id);
            if (roomAmenity == null)
            {
                return NotFound();
            }

            return View(roomAmenity);
        }

        // POST: RoomAmenities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RoomAmenities == null)
            {
                return Problem("Entity set 'TestDbContext.RoomAmenities'  is null.");
            }
            var roomAmenity = await _context.RoomAmenities.FindAsync(id);
            if (roomAmenity != null)
            {
                _context.RoomAmenities.Remove(roomAmenity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomAmenityExists(int id)
        {
          return _context.RoomAmenities.Any(e => e.ID == id);
        }
    }
}
