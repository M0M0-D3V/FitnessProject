using System.ComponentModel.DataAnnotations;

namespace FitnessProject.Models
{
    public class FavoriteClass
    {
        [Key]
        public int FavoriteClassId { get; set; }
        public string UserId { get; set; }
        public User FavoritedBy { get; set; }
        public int ClassId { get; set; }
        public Class FavoritedClass { get; set; }
    }
}