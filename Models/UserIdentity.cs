using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FitnessProject.Models
{
    public class UserIdentity : IdentityUser
    {
        public List<Class> Classes { get; set; }
        public UserIdentity()
        {
            Classes = new List<Class>();
        }
    }
}