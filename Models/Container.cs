using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FitnessProject.Models
{
    public class Container
    {
        public User LoggedUser { get; set; }
        public User User { get; set; }
        public List<User> AllUsers { get; set; }
        public Instructor LoggedInstructor { get; set; }
        public Instructor Instructor { get; set; }
        public List<Instructor> AllInstructors { get; set; }
        public Class Class { get; set; }
        public List<Class> AllClasses { get; set; }
        public List<Class> PastClasses { get; set; }
        public List<RSVP> AllRSVPs { get; set; }
        public int ClassesPerPage { get; set; }
        public int CurrentPage { get; set; }

        private int RandNum(int min, int max)
        {
            Random rand = new Random();
            int calc = rand.Next(min, max);
            return calc;
        }
        
        private List<string> PopulateList()
        {
            List<string> imgList = new List<string>();
            string sdira = "wwwroot/img";
            imgList = Directory.GetFiles(sdira, "*", SearchOption.AllDirectories).Select(x => Path.GetFileName(x)).ToList<string>();
            return imgList;
        }

        public string GetImage(string text)
        {
            List<string> images = PopulateList();
            List<string> newList = new List<string>();
            foreach (string img in images)
            {
                if (img.Contains(text))
                {
                    newList.Add(img);
                }
            }
            return newList[RandNum(0, newList.Count)];
        }
        public int PageCount()
        {
            return Convert.ToInt32(Math.Ceiling(AllClasses.Count() / (double)ClassesPerPage));
        }
        public List<Class> PaginatedClasses()
        {
            int start = (CurrentPage - 1) * ClassesPerPage;
            return AllClasses.OrderBy(b => b.ClassDate).Skip(start).Take(ClassesPerPage).ToList();
        }
    }
}