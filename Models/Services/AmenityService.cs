using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelSchema_Rewrite.Data;
using HotelSchema_Rewrite.Models.Interfaces;

namespace HotelSchema_Rewrite.Models.Services
{
    public class AmenityService : IAmenity
    {
        private readonly TestDbContext _context;

        public AmenityService(TestDbContext testDbContext)
        {
            _context = testDbContext;
        }

        // GET: Rooms/Create
        public async Task<Amenity> Create(Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return amenity;
        }

        public async Task<List<Amenity>> GetAmenities()
        {
            var amenity = await _context.Amenities.ToListAsync();
            return amenity;
        }


        public async Task<Amenity> GetAmenity(int id)
        {
            Amenity amenity = await _context.Amenities.FindAsync(id);
            return amenity;
        }

        public async Task<Amenity> UpdateAmenity(int id, Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenity;
        }

        public async Task Delete(int id)
        {
            Amenity amenity = await GetAmenity(id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
