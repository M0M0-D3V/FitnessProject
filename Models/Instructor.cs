using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace FitnessProject.Models
{
    public class Instructor
    {
        [Key]
        public int InstructorId { get; set; }
        public string InstructorPhoto { get; set; }
        public string Expertise { get; set; }
        public string Biography { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<Class> Classes { get; set; }
    }
}