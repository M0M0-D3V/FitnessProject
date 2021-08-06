using System.ComponentModel.DataAnnotations;

namespace FitnessProject.Models
{
    public class FavoriteInstructor
    {
        [Key]
        public int FavoriteInstructorId { get; set; }
        public string UserId { get; set; }
        public User FavoritedBy { get; set; }
        public int InstructorId { get; set; }
        public Instructor FavoritedInstructor { get; set; }
    }
}