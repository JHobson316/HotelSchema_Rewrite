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

namespace HotelSchema_Rewrite.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotel _context;

        public HotelsController(IHotel c)
        {
            _context = c;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
            var list = await _context.GetHotels();
            return list;
        }

        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            Hotel hotel = await _context.GetHotel(id);
            return hotel;
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> Create(int id, Hotel hotel)
        {
            if (id != hotel.ID)
            {
                return BadRequest();
            }
            var updatedHotel = await _context.UpdateHotel(id, hotel);
            return Ok(updatedHotel);
        }

        [HttpPost]
        public async Task<ActionResult<Hotel>> UpdateHotel(Hotel hotel)
        {
            await _context.Create(hotel);
            return CreatedAtAction("GetHotel", new { id = hotel.ID }, hotel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Edit(int id)
        {
            await _context.Delete(id);
            return NoContent();
        }
    }
}
