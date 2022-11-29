using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSchema_Rewrite.Models.Interfaces
{
    public interface IRoom
    {
        //Create
        Task<Room> Create(Room room);

        //Get All
        Task<List<Room>> GetRooms();

        //Get one By ID
        Task<Room> GetRoom(int id);

        // Update
        Task<Room> UpdateRoom(int id, Room room);

        //Delete
        Task Delete(int id);
    }
}