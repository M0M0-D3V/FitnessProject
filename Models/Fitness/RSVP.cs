using System.ComponentModel.DataAnnotations;

namespace FitnessProject.Models
{
    public class RSVP
    {
        [Key]
        public int RSVPId { get; set; }
        // bring in all the foreign keys
        public string UserId { get; set; }
        public User Attendee { get; set; }
        public int ClassId { get; set; }
        public Class Attending { get; set; }
    }
}