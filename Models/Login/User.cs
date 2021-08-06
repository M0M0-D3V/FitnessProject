using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace FitnessProject.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // public List<Class> Classes { get; set; }
        public List<RSVP> MyRSVPs { get; set; }
        public List<ReviewClass> MyReviews { get; set; }
        public List<ReviewInstructor> MyInstructorReviews { get; set; }
        public List<LikeClass> MyLikedClasses { get; set; }
        public List<LikeReview> MyLikedReviews { get; set; }
        public List<FavoriteClass> MyFavoriteClasses { get; set; }
        public List<FavoriteInstructor> MyFavoriteInstructors { get; set; }

        [InverseProperty("UserMessaged")]
        public List<Message> MessagesFrom { get; set; }

        [InverseProperty("MessageFrom")]
        public List<Message> UsersMessaged { get; set; }
        public User()
        {
            // Classes = new List<Class>();
            MyRSVPs = new List<RSVP>();
            MyReviews = new List<ReviewClass>();
            MyInstructorReviews = new List<ReviewInstructor>();
            MessagesFrom = new List<Message>();
            UsersMessaged = new List<Message>();
        }
    }
}