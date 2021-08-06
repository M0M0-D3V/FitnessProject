using System.ComponentModel.DataAnnotations;

namespace FitnessProject.Models
{
    public class LikeReview
    {
        [Key]
        public int LikeReviewId { get; set; }
        public string UserId { get; set; }
        public User LikedBy { get; set; }
        public int ReviewId { get; set; }
        public ReviewClass LikedClassReview { get; set; }
    }
}