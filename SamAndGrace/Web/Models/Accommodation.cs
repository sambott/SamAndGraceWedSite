using System.Security.Policy;

namespace Web.Models
{
    public abstract class Accommodation
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int DriveDistanceMinutes { get; set; }
        public Url Url { get; set; }
        public string PhoneNumber { get; set; }
        public int? StarRating { get; set; }
    }
}