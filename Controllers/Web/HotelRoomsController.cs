using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelSchema_Rewrite.Data;
using HotelSchema_Rewrite.Models;

namespace HotelSchema_Rewrite.Controllers.Web
{
    //[Route("[controller]")]
    public class HotelRoomsController : Controller
    {
        private readonly TestDbContext _context;

        public HotelRoomsController(TestDbContext context)
        {
            _context = context;
        }

        // GET: HotelRooms
        public async Task<IActionResult> Index()
        {
              return View(await _context.HotelRooms.ToListAsync());
        }

        // GET: HotelRooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HotelRooms == null)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRooms
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        // GET: HotelRooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HotelRooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelID,RoomNumber,ID,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hotelRoom);
        }

        // GET: HotelRooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HotelRooms == null)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRooms.FindAsync(id);
            if (hotelRoom == null)
            {
                return NotFound();
            }
            return View(hotelRoom);
        }

        // POST: HotelRooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HotelID,RoomNumber,ID,Rate,PetFriendly")] HotelRoom hotelRoom)
        {
            if (id != hotelRoom.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelRoomExists(hotelRoom.ID))
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
            return View(hotelRoom);
        }

        // GET: HotelRooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HotelRooms == null)
            {
                return NotFound();
            }

            var hotelRoom = await _context.HotelRooms
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hotelRoom == null)
            {
                return NotFound();
            }

            return View(hotelRoom);
        }

        // POST: HotelRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HotelRooms == null)
            {
                return Problem("Entity set 'TestDbContext.HotelRooms'  is null.");
            }
            var hotelRoom = await _context.HotelRooms.FindAsync(id);
            if (hotelRoom != null)
            {
                _context.HotelRooms.Remove(hotelRoom);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelRoomExists(int id)
        {
          return _context.HotelRooms.Any(e => e.ID == id);
        }
    }
}
