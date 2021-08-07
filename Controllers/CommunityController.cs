using System;
using System.Linq;
using FitnessProject.Models;
using FitnessProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitnessProject.Controllers
{
    [Authorize]
    public class CommunityController : Controller
    {
        private MyContext _db;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private IFitnessService _fitSvc;
        private IInstructorService _insSvc;
        private ICommunityService _commSvc;
        Container container;
        private string UserId{
            get { return _userManager.GetUserId(User);}
        }
        // here we can "inject" our context service into the constructor
        public CommunityController(MyContext context, UserManager<User> userManager, SignInManager<User> signInManager, IFitnessService fitService, IInstructorService insSvc, ICommunityService commSvc)
        {
            _db = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _fitSvc = fitService;
            _insSvc = insSvc;
            _commSvc = commSvc;
            container = new Container();
        }
        [HttpGet("class/{cId}/writereview")]
        [Authorize(Roles = "Student, Instructor, Admin")]
        public IActionResult WriteReview(int cId)
        {
            container.LoggedUser = _db.users.FirstOrDefault(x => x.Id == UserId);
            Instructor teacher = _insSvc.GetLoggedInsById(UserId);
            if(teacher != null)
            {
                container.LoggedInstructor = teacher;
            }
            container.Class = _fitSvc.GetById(cId);
            return View(container);
        }
        [HttpPost("class/{cId}/processreview")]
        [Authorize(Roles = "Student, Instructor, Admin")]
        public IActionResult ProcessReview(Container fromForm, int cId)
        {
            if (ModelState.IsValid)
            {
                _commSvc.CreateClassReview(fromForm.ReviewClass, UserId, cId);
                // return RedirectToAction("OneClass", "Fitness", cId);
                return Redirect($"/class/{cId}");
            }
            container.LoggedUser = _db.users.FirstOrDefault(x => x.Id == UserId);
            Instructor teacher = _insSvc.GetLoggedInsById(UserId);
            if(teacher != null)
            {
                container.LoggedInstructor = teacher;
            }
            container.Class = _fitSvc.GetById(cId);
            return View("WriteReview", container);
        }
    }
}