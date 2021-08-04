using System;
using System.Collections.Generic;
using System.Linq;
using FitnessProject.Models;
using FitnessProject.Services;
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
        private IFitnessService _fitSvc;
        private IInstructorService _insSvc;
        Container container;
        private string UserId{
            get { return _userManager.GetUserId(User);}
        }
        // here we can "inject" our context service into the constructor
        public FitnessController(MyContext context, UserManager<User> userManager, SignInManager<User> signInManager, IFitnessService fitService, IInstructorService insSvc)
        {
            _db = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _fitSvc = fitService;
            _insSvc = insSvc;
            container = new Container();
        }
        
        [HttpGet("")]
        [Authorize(Roles = "Student, Instructor, Admin")]
        public RedirectToActionResult Index()
        {
            return RedirectToAction("Dashboard", "Fitness");
        }

        [HttpGet("dashboard")]
        [Authorize(Roles = "Student, Instructor, Admin")]
        public IActionResult Dashboard(int page = 1)
        {
            container.LoggedUser = _db.users.FirstOrDefault(x => x.Id == UserId);
            Instructor teacher = _insSvc.GetLoggedInsById(UserId);
            if(teacher != null)
            {
                container.LoggedInstructor = teacher;
            }
            container.AllClasses = new List<Class>(_fitSvc.GetAll())
            .Where(a => a.ClassDate > DateTime.Now)
            .ToList();
            container.AllInstructors = new List<Instructor>(_insSvc.GetAll()).ToList();
            container.ClassesPerPage = 5;
            container.CurrentPage = page;
            return View(container);
        }

        [HttpGet("profile")]
        [Authorize(Roles = "Student, Instructor, Admin")]
        public IActionResult Profile()
        {
            container.LoggedUser = _db.users
            .Include(u => u.MyRSVPs)
            .FirstOrDefault(x => x.Id == UserId);
            // see if user is instructor
            Instructor teacher = _insSvc.GetLoggedInsById(UserId);
            if(teacher != null)
            {
                container.LoggedInstructor = teacher;
            }
            container.AllClasses = new List<Class>(_fitSvc.GetAll());
            return View(container);
        }

        [HttpGet("myclasses")]
        [Authorize(Roles = "Student, Instructor, Admin")]
        public IActionResult MyClasses()
        {
            container.LoggedUser = _db.users
            .FirstOrDefault(x => x.Id == UserId);
            // see if user is instructor
            Instructor teacher = _insSvc.GetLoggedInsById(UserId);
            if(teacher != null)
            {
                container.LoggedInstructor = teacher;
            }
            container.AllClasses = new List<Class>(_fitSvc.GetAll())
            .Where(a => a.Attending.Any(a => a.UserId == UserId) && a.ClassDate > DateTime.Now)
            .ToList();
            container.PastClasses = new List<Class>(_fitSvc.GetAll())
            .Where(a => a.Attending.Any(a => a.UserId == UserId) && a.ClassDate < DateTime.Now)
            .ToList();
            return View(container);
        }

        [HttpGet("instructor/all")]
        [Authorize(Roles = "Student, Instructor, Admin")]
        public IActionResult AllInstructors()
        {
            container.LoggedUser = _db.users
            .FirstOrDefault(x => x.Id == UserId);
            Instructor teacher = _insSvc.GetLoggedInsById(UserId);
            if(teacher != null)
            {
                container.LoggedInstructor = teacher;
            }
            container.AllInstructors = _insSvc.GetAll().ToList();
            return View(container);
        }

        [HttpGet("instructor/{insId}")]
        [Authorize(Roles = "Student, Instructor, Admin")]
        public IActionResult InstructorInfo(int insId)
        {
            container.LoggedUser = _db.users
            .FirstOrDefault(x => x.Id == UserId);
            container.Instructor = _insSvc.GetById(insId);
            Instructor teacher = _insSvc.GetLoggedInsById(UserId);
            if(teacher != null)
            {
                container.LoggedInstructor = teacher;
            }
            return View(container);
        }

        [HttpGet("edit-instructor/{id}")]
        [Authorize(Roles = "Instructor, Admin")]
        public IActionResult EditInstructorProfile(int id)
        {
            container.LoggedInstructor = _insSvc.GetLoggedInsById(UserId);
            return View(container);
        }

        [HttpGet("newclass")]
        [Authorize(Roles = "Instructor, Admin")]
        public IActionResult NewClass()
        {
            container.LoggedUser = _db.users.FirstOrDefault(x => x.Id == UserId);
            container.LoggedInstructor = _insSvc.GetLoggedInsById(UserId);
            return View(container);
        }

        [HttpGet("class/{classId}/edit")]
        [Authorize(Roles = "Instructor, Admin")]
        public IActionResult EditClass(int classId)
        {
            container.LoggedUser = _db.users.FirstOrDefault(x => x.Id == UserId);
            container.LoggedInstructor = _insSvc.GetLoggedInsById(UserId);
            container.Class = _fitSvc.GetById(classId);
            return View(container);
        }

        [HttpPost("processclass")]
        [Authorize(Roles = "Instructor, Admin")]
        public IActionResult ProcessClass(Container fromForm)
        {
            Console.WriteLine(fromForm.Class.ClassDate);
            if (fromForm.Class.ClassDate < DateTime.Now)
            {
                ModelState.AddModelError("Class.ClassDate", "Class Date must be in the future");
            }
            if (ModelState.IsValid)
            {
                Instructor teacher = _insSvc.GetLoggedInsById(UserId);
                Console.WriteLine($"Instructor ID: {teacher.InstructorId}");
                _fitSvc.Create(fromForm.Class, teacher.InstructorId);
                return RedirectToAction("Dashboard", "Fitness");
            }
            User u = _db.users.FirstOrDefault(u => u.Id == UserId);
            fromForm.LoggedUser = u;
            fromForm.LoggedInstructor = _insSvc.GetLoggedInsById(UserId);
            return View("NewClass", fromForm);
        }

        [HttpPost("class/{classId}/update")]
        [Authorize(Roles = "Instructor, Admin")]
        public IActionResult UpdateClass(Container fromForm, int classId)
        {
            Console.WriteLine(fromForm.Class.ClassDate);
            if (fromForm.Class.ClassDate < DateTime.Now)
            {
                ModelState.AddModelError("Class.ClassDate", "Class Date must be in the future");
            }
            if (ModelState.IsValid)
            {
                Class updatedClass = _fitSvc.Update(fromForm.Class, classId);
                return RedirectToAction("OneClass", "Fitness", classId);
            }
            User u = _db.users.FirstOrDefault(u => u.Id == UserId);
            container.LoggedUser = u;
            container.LoggedInstructor = _insSvc.GetLoggedInsById(UserId);
            container.Class = _fitSvc.GetById(classId);
            return View("EditClass", container);
        }

        [HttpPost("process-instructor/{id}")]
        [Authorize(Roles = "Instructor, Admin")]
        public IActionResult ProcessInstructor(Container fromForm, int id)
        {
            _insSvc.Update(fromForm.LoggedInstructor, id);
            return RedirectToAction("Profile", "Fitness");
        }

        [HttpGet("class/{classId}")]
        [Authorize(Roles = "Student, Instructor, Admin")]
        public IActionResult OneClass(int classId)
        {
            container.LoggedUser = _db.users.FirstOrDefault(x => x.Id == UserId);
            container.LoggedInstructor = _insSvc.GetLoggedInsById(UserId);
            container.Class = _fitSvc.GetById(classId);
            container.AllRSVPs = new List<RSVP>(_fitSvc.GetAllRSVPs(classId));
            return View(container);
        }

        [HttpGet("class/{classId}/delete")]
        [Authorize(Roles = "Student, Instructor, Admin")]
        public IActionResult DeleteClass(int classId)
        {
            Instructor teacher = _insSvc.GetLoggedInsById(UserId);
            if(teacher != null)
            {
                _fitSvc.Delete(classId, teacher.InstructorId);
            }
            return RedirectToAction("Dashboard", "Fitness");
        }

        [HttpGet("class/{classId}/rsvp")]
        [Authorize(Roles = "Student, Instructor, Admin")]
        public IActionResult RSVP(int classId)
        {
            _fitSvc.RSVP(UserId, classId);
            return RedirectToAction("OneClass", "Fitness", classId);
        }

        [HttpGet("class/{classId}/un-rsvp")]
        [Authorize(Roles = "Student, Instructor, Admin")]
        public IActionResult UnRSVP(int classId)
        {
            _fitSvc.UnRSVP(UserId, classId);
            return RedirectToAction("Dashboard", "Fitness");
        }
    }
}