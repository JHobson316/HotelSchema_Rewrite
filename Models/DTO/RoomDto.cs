namespace HotelSchema_Rewrite.Models.DTO
{
    public class RoomDto
    {
        public string Name { get; set; }
        public int Layout { get; set; }
        public List<RoomDto> Rooms { get; set; }
    }
}
