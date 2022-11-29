namespace HotelSchema_Rewrite.Models.DTO
{
    public class AmenityDto
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<AmenityDto> Amenities { get; set; }
    }
    public class AmenityDetailDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
