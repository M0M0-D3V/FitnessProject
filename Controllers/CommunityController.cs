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
        Container container;
        private string UserId{
            get { return _userManager.GetUserId(User);}
        }
        // here we can "inject" our context service into the constructor
        public CommunityController(MyContext context, UserManager<User> userManager, SignInManager<User> signInManager, IFitnessService fitService, IInstructorService insSvc)
        {
            _db = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _fitSvc = fitService;
            _insSvc = insSvc;
            container = new Container();
        }
    }
}