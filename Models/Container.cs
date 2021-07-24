using System.Collections.Generic;

namespace FitnessProject.Models
{
    public class Container
    {
        public User LoggedUser { get; set; }
        public Instructor LoggedInstructor { get; set; }
        public List<User> AllUsers { get; set; }
        public Class Class { get; set; }
        public List<Class> AllClasses { get; set; }
        public List<RSVP> AllRSVPs { get; set; }
        public List<Class> PastClasses { get; set; }
    }
}