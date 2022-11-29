using System.Security.Cryptography.X509Certificates;

namespace HotelSchema_Rewrite.Models
{
    public class Hotel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string streetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
    }
}
