using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using HotelSchema_Rewrite.Models;
using HotelSchema_Rewrite.Models.DTO;

namespace HotelSchema_Rewrite.Data
{
    //public class NewDbContext : IdentityDbContext<ApplicationUser>
    //{
    //    public NewDbContext(DbContextOptions options) : base(options =>
    //    {
    //        options.User.RequireUniqueEmail = true;
    //    })
    //}

    public class TestDbContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<RoomAmenity> RoomAmenities { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        //public DbSet<Login> Login { get; set; }
        public TestDbContext(DbContextOptions options) : base(options)
        {
            //ModelBuilder.Entity<Hotel>.HasData(new Hotel { City = "Memphis", Country = "USA", ID = 1, Name = "The Andalusian", Phone = "901-555-1999", State = "TN", streetAddress = "2014 Sam Cooper Blvd"});
            //ModelBuilder.Entity<Room>.hasData(new Room { ID = 1, Name = "Presidential Suite", Layout = 2});
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Country = "USA",
                    ID = 1,
                    Name = "The Andalusian",
                    Phone = "901-555-1999",
                    State = "TN",
                    City = "Memphis",
                    streetAddress = "2014 Sam Cooper Blvd"
                },

                new Hotel
                {
                    Name = "Arcadian Suites",
                    Phone = "675-555-2603",
                    ID = 2,
                    Country = "USA",
                    State = "CA",
                    City = "San Francisco",
                    streetAddress = "2648 Plusolder Lane"
                }
            );
            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    ID = 1,
                    Layout = 2,
                    Name = "Presidential Suite"
                }
            );
            modelBuilder.Entity<Amenity>().HasData(
                new Amenity
                {
                    ID = 1,
                    Name = "Hot Tub"
                }
            );
            modelBuilder.Entity<HotelRoom>().HasData(
                new HotelRoom
                {
                    HotelID = 2,
                    ID = 626,
                    PetFriendly = false,
                    Rate = 59.99m,
                    RoomNumber = 205
                }
                );

            

        }
        public DbSet<HotelSchema_Rewrite.Models.DTO.UserDto> UserDto { get; set; }
        public DbSet<HotelSchema_Rewrite.Models.DTO.LoginDto> LoginDto { get; set; }
        public DbSet<HotelSchema_Rewrite.Models.DTO.RegisterUserDto> RegisterUserDto { get; set; }
    }
}
