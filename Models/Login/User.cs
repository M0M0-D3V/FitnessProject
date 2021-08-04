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
        public List<Review> MyReviews { get; set; }

        [InverseProperty("UserMessaged")]
        public List<Message> MyMessages { get; set; }

        [InverseProperty("MyMessage")]
        public List<Message> UsersMessaged { get; set; }
        public User()
        {
            // Classes = new List<Class>();
            MyRSVPs = new List<RSVP>();
            MyReviews = new List<Review>();
            MyMessages = new List<Message>();
            UsersMessaged = new List<Message>();
        }
    }
}