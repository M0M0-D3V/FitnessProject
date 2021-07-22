using System;
using System.Linq;
using FitnessProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessProject.Controllers
{
    [Authorize]
    public class FitnessController : Controller
    {
        private MyContext _db;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        // here we can "inject" our context service into the constructor
        public FitnessController(MyContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _db = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        [HttpGet("")]
        [Authorize(Roles = "Student, Instructor, Admin")]
        public RedirectToActionResult Index()
        {
            return RedirectToAction("Dashboard", "Fitness");
        }

        [HttpGet("dashboard")]
        [Authorize(Roles = "Student, Instructor, Admin")]
        public IActionResult Dashboard()
        {
            string UserId = _userManager.GetUserId(User);
            Container container = new Container();
            container.LoggedUser = _db.users.FirstOrDefault(x => x.Id == UserId);
            container.AllClasses = _db.Classes
            .Include(c => c.Instructor)
            .Include(w => w.Attending)
            .ThenInclude(u => u.Attendee)
            .ToList();
            return View(container);
        }

        [HttpGet("profile")]
        [Authorize(Roles = "Student, Instructor, Admin")]
        public IActionResult Profile()
        {
            string UserId = _userManager.GetUserId(User);
            Container container = new Container();
            container.LoggedUser = _db.users.FirstOrDefault(x => x.Id == UserId);
            // see if user is instructor
            Instructor teacher = _db.Instructors
            .Include(t => t.User)
            .Include(t => t.Classes)
            .FirstOrDefault(t => t.UserId == UserId);
            if(teacher != null)
            {
                container.LoggedInstructor = teacher;
            }
            container.AllClasses = _db.Classes
            .Include(c => c.Instructor)
            .Include(w => w.Attending)
            .ThenInclude(u => u.Attendee)
            .ToList();
            return View(container);
        }


        [HttpGet("newclass")]
        [Authorize(Roles = "Instructor, Admin")]
        public IActionResult NewClass()
        {
            string UserId = _userManager.GetUserId(User);
            Container container = new Container();
            container.LoggedUser = _db.users.FirstOrDefault(x => x.Id == UserId);
            return View(container);
        }

        [HttpPost("processclass")]
        [Authorize(Roles = "Instructor, Admin")]
        public IActionResult ProcessClass(Container fromForm)
        {
            // check wedding date if in future
            string UserId = _userManager.GetUserId(User);
            Console.WriteLine(fromForm.Class.ClassDate);
            if (fromForm.Class.ClassDate < DateTime.Now)
            {
                ModelState.AddModelError("Class.ClassDate", "Class Date must be in the future");
            }
            if (ModelState.IsValid)
            {
                Console.WriteLine("made it to 96");

                // all is good
                Instructor teacher = _db.Instructors.FirstOrDefault(t => t.UserId == UserId);
                Console.WriteLine($"Instructor ID: {teacher.InstructorId}");
                fromForm.Class.InstructorId = teacher.InstructorId;
                _db.Classes.Add(fromForm.Class);
                _db.SaveChanges();
                Console.WriteLine($"successfully added {fromForm.Class.ClassName} on {fromForm.Class.ClassDate}");
                return RedirectToAction("Dashboard", "Fitness");
            }
            User u = _db.users.FirstOrDefault(u => u.Id == UserId);
            fromForm.LoggedUser = u;
            // show a view with a form
            return View("NewClass", fromForm);
        }
        // [HttpGet("class/{classId}")]
        // public IActionResult OneClass(int classId)
        // {
        //     if (!isLoggedIn)
        //     {
        //         return RedirectToAction("Index", "Home");
        //     }
        //     User u = _db.Users.FirstOrDefault(u => u.UserId == (int)uid);
        //     Container container = new Container();
        //     container.LoggedUser = u;
        //     container.Class = _db.Classes.FirstOrDefault(w => w.ClassId == classId);
        //     container.AllRSVPs = _db.RSVPs
        //     .Where(r => r.ClassId == classId)
        //     .Include(r => r.Attendee)
        //     .Include(e => e.AttendeeOf)
        //     .ThenInclude(u => u.Instructor)
        //     .ToList();
        //     return View(container);
        // }
    }
}