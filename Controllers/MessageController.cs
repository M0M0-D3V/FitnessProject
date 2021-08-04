using System;
using System.Collections.Generic;
using System.Linq;
using FitnessProject.Models;
using FitnessProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitnessProject.Controllers
{
    [Authorize]
    public class MessageController : Controller
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
        public MessageController(MyContext context, UserManager<User> userManager, SignInManager<User> signInManager, IFitnessService fitService, IInstructorService insSvc)
        {
            _db = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _fitSvc = fitService;
            _insSvc = insSvc;
            container = new Container();
        }
        [HttpGet("inbox")]
        [Authorize(Roles = "Student, Instructor, Admin")]
        public IActionResult Inbox()
        {
            container.LoggedUser = _db.users.FirstOrDefault(x => x.Id == UserId);
            Instructor teacher = _insSvc.GetLoggedInsById(UserId);
            if(teacher != null)
            {
                container.LoggedInstructor = teacher;
            }
            container.AllUsers = _db.users.ToList();
            container.AllInstructors = new List<Instructor>(_insSvc.GetAll()).ToList();
            // [] need svc lists for messages
            // container.ReceivedMessages
            // container.SentMessages
            return View(container);
        }
    }
}