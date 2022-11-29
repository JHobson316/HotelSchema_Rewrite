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
    public class RoomsController : ControllerBase
    {
        private readonly IRoom _context;

        public RoomsController(IRoom c)
        {
            _context = c;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            var list = await _context.GetRooms();
            return list;
        }

        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            Room room = await _context.GetRoom(id);
            return room;
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> Create(int id, Room room)
        {
            if (id != room.ID)
            {
                return BadRequest();
            }
            var updatedRoom = await _context.UpdateRoom(id, room);
            return Ok(updatedRoom);
        }

        [HttpPost]
        public async Task<ActionResult<Room>> UpdateHotel(Room room)
        {
            await _context.Create(room);
            return CreatedAtAction("GetRoom", new { id = room.ID }, room);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Edit(int id)
        {
            await _context.Delete(id);
            return NoContent();
        }
    }
}
