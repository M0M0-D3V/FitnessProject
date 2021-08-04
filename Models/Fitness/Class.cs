using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessProject.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
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
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }

        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Max # of People")]
        public int ClassSize { get; set; }

        [Required]
        [Display(Name = "Class Photo")]
        public string ClassPhoto { get; set; }

        [Display(Name = "Class Video")]
        public string ClassVideo { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        // foreign key
        public int InstructorId { get; set; }
        // navigational property
        public Instructor Instructor { get; set; }
        // many to many
        public List<RSVP> Attending { get; set; }
    }
}