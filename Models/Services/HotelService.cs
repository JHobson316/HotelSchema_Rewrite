using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelSchema_Rewrite.Data;
using HotelSchema_Rewrite.Models.Interfaces;
using HotelSchema_Rewrite.Models;

namespace HotelSchema_Rewrite.Models.Services
{
    public class HotelService : IHotel
    {
        private readonly TestDbContext _context;

        public HotelService(TestDbContext testDbContext)
        {
            _context = testDbContext;
        }

        // GET: Rooms/Create
        public async Task<Hotel> Create(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task<List<Hotel>> GetHotels()
        {
            var hotel = await _context.Hotels.ToListAsync();
            return hotel;
        }


        public async Task<Hotel> GetHotel(int id)
        {
            Hotel hotel = await _context.Hotels.FindAsync(id);
            return hotel;
        }

        public async Task<Hotel> UpdateHotel(int id, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task Delete(int id)
        {
            Hotel hotel = await GetHotel(id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
