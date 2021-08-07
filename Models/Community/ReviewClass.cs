using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessProject.Models
{
    public class ReviewClass
    {
        [Key]
        public int ReviewClassId { get; set; }
        [Required(ErrorMessage = "Review needs a title")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Review needs a body")]
        public string Content { get; set; }
        [Required(ErrorMessage = "Review needs a rating")]
        public int Rating { get; set; }
        public string UserId { get; set; }
        public User Reviewer { get; set; }
        public int ClassId { get; set; }
        public Class ReviewedClass { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
    
}