using System.ComponentModel.DataAnnotations;

namespace FitnessProject.Models
{
    public class LikeClass
    {
        [Key]
        public int LikeClassId { get; set; }
        public string UserId { get; set; }
        public User LikedBy { get; set; }
        public int ClassId { get; set; }
        public Class LikedClass { get; set; }
        
    }
}