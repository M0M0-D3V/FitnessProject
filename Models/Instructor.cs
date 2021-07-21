using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace FitnessProject.Models
{
    public class Instructor : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Expertise { get; set; }
        public string Biography { get; set; }
        public List<Class> Classes { get; set; }
        // public List<RSVP> MyRSVPs { get; set; }
        public Instructor()
        {
            Classes = new List<Class>();
            // MyRSVPs = new List<RSVP>();
        }
    }
}