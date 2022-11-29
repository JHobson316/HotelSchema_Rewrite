using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSchema_Rewrite.Models.Interfaces
{
    public interface IAmenity
    {
        //Create
        Task<Amenity> Create(Amenity amenity);

        //Get All
        Task<List<Amenity>> GetAmenities();
        
        //Get one By ID
        Task<Amenity> GetAmenity(int id);

        // Update
        Task<Amenity> UpdateAmenity(int id, Amenity amenity);

        //Delete
        Task Delete(int id);
    }
}