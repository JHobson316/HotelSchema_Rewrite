using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSchema_Rewrite.Models.Interfaces
{
    public interface IHotel
    {
        //Create
        Task<Hotel> Create(Hotel hotel);

        //Get All
        Task<List<Hotel>> GetHotels();

        //Get one By ID
        Task<Hotel> GetHotel(int id);

        // Update
        Task<Hotel> UpdateHotel(int id, Hotel hotel);

        //Delete
        Task Delete(int id);
    }
}