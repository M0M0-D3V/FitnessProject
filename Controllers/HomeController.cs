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
        private MyContext _db;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private int? uid
        {
            get { return HttpContext.Session.GetInt32("UserId"); }
        }
        private bool isLoggedIn
        {
            get { return uid != null; }
        }

        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _db = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // [HttpGet("")]

        // public IActionResult Index()
        // {
        //     if (!isLoggedIn)
        //     {
        //         return View();
        //     }
        //     return RedirectToAction("Dashboard", "Fitness");
        // }

        // ************************************WEIRD STUFF HERE********************
        private Task<User> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

        [HttpGet("logout")]
        [Authorize]
        public async Task<RedirectToActionResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Fitness");
        }



        [HttpGet("signin")]
        [AllowAnonymous]
        public IActionResult Signin(string returnUrl)
        {
            var UserId = _userManager.GetUserId(User);
            if (UserId != null) return RedirectToAction("Index", "Fitness");
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.Count = 0;


            return View();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
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
            return View("signin");
        }


        [HttpPost("register")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterUser(RegisterViewModel model, string returnUrl)
        {
            int count = 0;
            if (ModelState.IsValid)
            {
                //Create a new User object, without adding a Password
                User NewUser = new User { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName };
                //CreateAsync will attempt to create the User in the database, simultaneously hashing the
                //password
                IdentityResult result = await _userManager.CreateAsync(NewUser, model.Password);
                //If the User was added to the database successfully
                if (result.Succeeded)
                {
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
            return View("signin");
        }
        // ************************************WEIRD STUFF DONE********************


        // [HttpPost("register")]
        // public IActionResult Register(User user)
        // {
        //     // some stuff to do
        //     // check the validation
        //     if (ModelState.IsValid)
        //     {
        //         // If a User exists with provided email
        //         if (_db.Users.Any(u => u.Email == user.Email))
        //         {
        //             // Manually add a ModelState error to the Email field, with provided
        //             // error message
        //             ModelState.AddModelError("Email", "Email already in use!");
        //             return View("Index");
        //         }
        //         // validation is good and email is unique
        //         // save user to db after hashing password
        //         PasswordHasher<User> Hasher = new PasswordHasher<User>();
        //         user.Password = Hasher.HashPassword(user, user.Password);
        //         _db.Users.Add(user);
        //         _db.SaveChanges();
        //         HttpContext.Session.SetInt32("UserId", user.UserId);
        //         // redirecting to Dashboard() in WeddingController
        //         return RedirectToAction("Dashboard", "Fitness");
        //     }
        //     // if we made it here, validation is wrong from the start
        //     return View("Index");
        // }
        // [HttpPost("letmein")]
        // public IActionResult LetMeIn(LoginUser lu)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         // checking if everything is good!
        //         // still gotta check if user pw matches hashed in db
        //         User getUser = _db.Users.FirstOrDefault(u => u.Email == lu.LoginEmail);
        //         // If no user exists with provided email
        //         if (getUser == null)
        //         {
        //             // Add an error to ModelState and return to View!
        //             ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
        //             return View("Index");
        //         }
        //         // Initialize hasher object
        //         var hasher = new PasswordHasher<LoginUser>();
        //         // verify provided password against hash stored in db
        //         var result = hasher.VerifyHashedPassword(lu, getUser.Password, lu.LoginPassword);
        //         if (result == 0) // 0 means failure
        //         {
        //             // handle failure (this should be similar to how "existing email" is handled)
        //             ModelState.AddModelError("LoginPassword", "Invalid Email/Password");
        //             return View("Index");
        //         }
        //         // if we get here, user is good!
        //         HttpContext.Session.SetInt32("UserId", getUser.UserId);
        //         return RedirectToAction("Dashboard", "Fitness");
        //     }
        //     // if we reach here, it is no good
        //     return View("Index");
        // }

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
