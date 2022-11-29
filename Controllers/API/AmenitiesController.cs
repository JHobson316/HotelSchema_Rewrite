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
    public class AmenitiesController : ControllerBase
    {
        private readonly IAmenity _context;

        public AmenitiesController(IAmenity c)
        {
            _context = c;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Amenity>>> GetAmenities()
        {
            var list = await _context.GetAmenities();
            return list;
        }

        public async Task<ActionResult<Amenity>> GetAmenities(int id)
        {
            Amenity amenity = await _context.GetAmenity(id);
            return amenity;
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> Create(int id, Amenity amenity)
        {
            if (id != amenity.ID)
            {
                return BadRequest();
            }
            var updatedAmenity = await _context.UpdateAmenity(id, amenity);
            return Ok(updatedAmenity);
        }

        [HttpPost]
        public async Task<ActionResult<Amenity>> UpdateAmenity(Amenity amenity)
        {
            await _context.Create(amenity);
            return CreatedAtAction("GetAmenity", new { id = amenity.ID }, amenity);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Edit(int id)
        {
            await _context.Delete(id);
            return NoContent();
        }
    }
}
