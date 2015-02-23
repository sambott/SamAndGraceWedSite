using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Rsvp
    {
        public int Id { get; set; }
        public DateTime RsvpdAt { get; set; }
        public string Name { get; set; }
        public bool Attending { get; set; }
        public bool RequiresTransport { get; set; }
        public string DietryRequirements { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}