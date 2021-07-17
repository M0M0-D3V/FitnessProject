using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FitnessProject.Models
{
    public class User : IdentityUser
    {
        public List<Class> Classes { get; set; }
        public User()
        {
            Classes = new List<Class>();
        }
    }
}