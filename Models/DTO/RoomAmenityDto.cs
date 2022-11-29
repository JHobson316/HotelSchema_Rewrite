namespace HotelSchema_Rewrite.Models.DTO
{
    public class RoomAmenityDto
    {
        public int RoomID { get; set; }
        public List<RoomAmenityDto> RoomAmenities { get; set; }
    }
}
