using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FitnessProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

namespace FitnessProject.Controllers
{
    public class HomeController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private MyContext _db;
        private string UserId{
            get { return _userManager.GetUserId(User);}
        }
        public HomeController(MyContext context, UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleMgr)
        {
            _db = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleMgr;
        }

        private Task<User> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

        [HttpGet("Logout")]
        [Authorize(Roles = "Student, Instructor, Admin")]
        public async Task<RedirectToActionResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Fitness");
        }

        [HttpGet("Signin")]
        [AllowAnonymous]
        public IActionResult Signin(string returnUrl)
        {
            if (UserId != null)
            {
                return RedirectToAction("Index", "Fitness");
            }
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.Count = 0;
            return View();
        }
        [HttpGet("instructor-signin")]
        [AllowAnonymous]
        public IActionResult InstructorSignin(string returnUrl)
        {
            if (UserId != null) return RedirectToAction("Index", "Fitness");
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.Count = 0;
            return View();
        }
        [HttpGet("admin-signin")]
        [AllowAnonymous]
        public IActionResult AdminSignin(string returnUrl)
        {
            if (UserId != null) return RedirectToAction("Index", "Fitness");
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.Count = 0;
            return View();
        }

        [HttpPost("UserLogin")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UserLogin(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(email: model.LoginEmail);
                if (user != null && await _userManager.CheckPasswordAsync(user, password: model.LoginPassword))
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("LoginEmail", "Invalid email or password.");
                }
            }
            ViewBag.ReturnUrl = returnUrl;
            return View("Signin");
        }

        [HttpPost("InstructorLogin")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> InstructorLogin(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(email: model.LoginEmail);
                if (user != null && await _userManager.CheckPasswordAsync(user, password: model.LoginPassword))
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("LoginEmail", "Invalid email or password.");
                }
            }
            ViewBag.ReturnUrl = returnUrl;
            return View("InstructorSignin");
        }

        [HttpPost("UserRegister")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserRegister(RegisterViewModel model, string returnUrl)
        {
            int count = 0;
            if (ModelState.IsValid)
            {
                var roleExist = await _roleManager.RoleExistsAsync("Student");
                // If a Role doesn't already exist, create it
                if(!roleExist)
                {
                    IdentityResult roleResult = await _roleManager.CreateAsync(new IdentityRole("Student"));
                }
                //Create a new User object, without adding a Password
                User NewUser = new User { UserName = model.FirstName, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName };
                //CreateAsync will attempt to create the User in the database, simultaneously hashing the
                //password
                IdentityResult result = await _userManager.CreateAsync(NewUser, model.Password);
                //If the User was added to the database successfully
                if (result.Succeeded)
                {
                    // Each new user is added to the "Level1" Role
                    await _userManager.AddToRoleAsync(NewUser, "Student");
                    //Sign In the newly created User
                    //We're using the SignInManager, not the UserManager!
                    await _signInManager.SignInAsync(NewUser, isPersistent: false);
                    return RedirectToLocal(returnUrl);
                }
                //If the creation failed, add the errors to the View Model
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description.Replace("Username", "Email"));
                    count++;
                }
            }
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.Count = count;
            return View("Signin");
        }

        [HttpPost("InstructorRegister")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InstructorRegister(RegisterViewModel model, string returnUrl)
        {
            int count = 0;
            if (ModelState.IsValid)
            {
                var roleExist = await _roleManager.RoleExistsAsync("Instructor");
                // If a Role doesn't already exist, create it
                if(!roleExist)
                {
                    IdentityResult roleResult = await _roleManager.CreateAsync(new IdentityRole("Instructor"));
                }

                //Create a new User object, without adding a Password
                User NewUser = new User { UserName = model.FirstName, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName };
                //CreateAsync will attempt to create the User in the database, simultaneously hashing the
                //password
                IdentityResult result = await _userManager.CreateAsync(NewUser, model.Password);
                //If the User was added to the database successfully
                if (result.Succeeded)
                {
                    // Each new user is added to the "Level1" Role
                    await _userManager.AddToRoleAsync(NewUser, "Instructor");
                    //Sign In the newly created User
                    //We're using the SignInManager, not the UserManager!
                    await _signInManager.SignInAsync(NewUser, isPersistent: false);
                    Instructor newTeacher = new Instructor();
                    newTeacher.UserId = NewUser.Id;
                    _db.Instructors.Add(newTeacher);
                    _db.SaveChanges();
                    return RedirectToLocal(returnUrl);
                }
                //If the creation failed, add the errors to the View Model
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description.Replace("Username", "Email"));
                    count++;
                }
            }
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.Count = count;
            return View("InstructorSignin");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Fitness");
            }
        }
    }
}
