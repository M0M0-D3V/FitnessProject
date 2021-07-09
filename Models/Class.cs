using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessProject.Models
{
    public class Class
    {
        [Key]
        public int WeddingId { get; set; }
        [Required]
        [Display(Name = "Class Name")]
        public string ClassName { get; set; }

        [Required]
        [Display(Name = "Description")]

        public string ClassDescription { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime ClassDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Time")]
        public DateTime ClassTime { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        [Display(Name = "Duration Type")]
        public string DurationType { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        // foreign key
        public int UserId { get; set; }
        // navigational property
        public User Instructor { get; set; }
        // many to many
        public List<RSVP> Attending { get; set; }
    }
}