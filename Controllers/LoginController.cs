using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Cryptography;
using WebProgrammingAflevering.Data;
using WebProgrammingAflevering.Models.Entities;
using WebProgrammingAflevering.Models.ViewModels;

namespace WebProgrammingAflevering.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _dbContext;


        //Create a link to the database
        public LoginController(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        
        //The Index is the main login page
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Looking for a user in the system with the right email and password 
                var user = await _dbContext.Users.Where(x => x.Email == viewModel.Email && x.Password == viewModel.Password).FirstOrDefaultAsync();

                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                    };

                    // Making the cookies that is used for authentication
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Index", "Post");
                }
                else 
                {
                    ModelState.AddModelError("", "Email or Password is not correct");
                }
            
            }

            return View(viewModel);

        }

        public async Task<IActionResult> LogOut() 
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Register() 
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(AddUserViewModel viewModel)
        {
            bool userExists = await _dbContext.Users.AnyAsync(x => x.Id == viewModel.Id);

            if (userExists) 
            {
                ViewBag.Message = $"User with the email {viewModel.Email} already exists.";
                return View();
            }

            if (ModelState.IsValid) 
            {
                User newUser = new User();
                newUser.Email = viewModel.Email;
                newUser.Password = viewModel.Password;
                newUser.Username = viewModel.Username;
                
                await _dbContext.Users.AddAsync(newUser);
                await _dbContext.SaveChangesAsync();

                ModelState.Clear();
                ViewBag.Message = $"{newUser.Email} registered successfully. You can now login";

                return View();
            }
            
            return View(viewModel);

        }

    }
}
