namespace HotelSchema_Rewrite.Models.DTO
{
    public class HotelRoomDto
    {
        public int ID { get; set; }
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }
        public List<HotelRoomDto> HotelRooms { get; set; }
    }
}
