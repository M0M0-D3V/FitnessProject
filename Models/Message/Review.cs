using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessProject.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        [Required(ErrorMessage = "Review needs a title")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Review needs a content")]
        public string Content { get; set; }

        public string UserId { get; set; }
        public User Reviewer { get; set; }
        public int ClassId { get; set; }
        public Class ClassReviewed { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}