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
    public class RoomsService : IRoom
    {
        private readonly TestDbContext _context;

        public RoomsService(TestDbContext testDbContext)
        {
            _context = testDbContext;
        }

        // GET: Rooms/Create
        public async Task<Room> Create(Room room)
        {
            _context.Entry(room).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task<List<Room>> GetRooms()
        {
            var room = await _context.Rooms.ToListAsync();
            return room;
        }

        
        public async Task<Room> GetRoom(int id)
        {
            Room room = await _context.Rooms.FindAsync(id);
            return room;
        }

        public async Task<Room> UpdateRoom(int id, Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task Delete(int id)
        {
            Room room = await GetRoom(id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
