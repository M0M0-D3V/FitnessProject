using System;
using System.Linq;
using FitnessProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessProject.Controllers
{
    public class FitnessController : Controller
    {
        private MyContext _db;
        private int? uid
        {
            get { return HttpContext.Session.GetInt32("UserId"); }
        }
        private bool isLoggedIn
        {
            get { return uid != null; }
        }

        // here we can "inject" our context service into the constructor
        public FitnessController(MyContext context)
        {
            _db = context;
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }
            // query user and put in container
            User u = _db.Users.FirstOrDefault(u => u.UserId == (int)uid);
            Container container = new Container();
            container.LoggedUser = u;
            container.AllClasses = _db.Classes
            .Include(c => c.Instructor)
            .Include(w => w.Attending)
            .ThenInclude(u => u.Attendee)
            .ToList();
            return View(container);
        }
        [HttpGet("newclass")]
        public IActionResult NewClass()
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }
            User u = _db.Users.FirstOrDefault(u => u.UserId == (int)uid);
            Container container = new Container();
            container.LoggedUser = u;
            // show a view with a form
            return View(container);
        }

        [HttpPost("processclass")]
        public IActionResult ProcessClass(Container fromForm)
        {
            // check wedding date if in future
            Console.WriteLine(fromForm.Class.ClassDate);
            if (fromForm.Class.ClassDate < DateTime.Now)
            {
                ModelState.AddModelError("Class.ClassDate", "Class Date must be in the future");
            }
            if (ModelState.IsValid)
            {
                // all is good
                fromForm.Class.UserId = (int)uid;
                _db.Classes.Add(fromForm.Class);
                _db.SaveChanges();
                Console.WriteLine($"successfully added {fromForm.Class.ClassName} on {fromForm.Class.ClassDate}");
                return RedirectToAction("Dashboard", "Fitness");
            }
            User u = _db.Users.FirstOrDefault(u => u.UserId == (int)uid);
            fromForm.LoggedUser = u;
            // show a view with a form
            return View("NewClass", fromForm);
        }
        [HttpGet("class/{classId}")]
        public IActionResult OneClass(int classId)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }
            User u = _db.Users.FirstOrDefault(u => u.UserId == (int)uid);
            Container container = new Container();
            container.LoggedUser = u;
            container.Class = _db.Classes.FirstOrDefault(w => w.ClassId == classId);
            container.AllRSVPs = _db.RSVPs
            .Where(r => r.ClassId == classId)
            .Include(r => r.Attendee)
            .Include(e => e.AttendeeOf)
            .ThenInclude(u => u.Instructor)
            .ToList();
            return View(container);
        }
    }
}