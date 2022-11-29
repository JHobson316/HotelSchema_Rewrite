namespace HotelSchema_Rewrite.Models.DTO
{
    public class HotelDto
    {
        public string Name { get; set; }
        public string streetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string Rating { get; set; }
        public List<HotelDto> Hotels { get; set; }
    }
}
