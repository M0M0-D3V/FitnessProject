using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public User()
        {
            // Classes = new List<Class>();
            MyRSVPs = new List<RSVP>();
        }
    }
}