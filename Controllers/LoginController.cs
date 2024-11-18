using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using WebProgrammingAflevering.Data;
using WebProgrammingAflevering.Models.Entities;
using WebProgrammingAflevering.Models.ViewModels;

namespace WebProgrammingAflevering.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public LoginController(ApplicationDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }



        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Index() 
        //{
            
        //}


        [HttpGet]
        public IActionResult Register() 
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(AddUserViewModel viewModel, User Users)
        {
            bool userExists = await dbContext.Users.AnyAsync(x=>x.Email == Users.Email);

            if (userExists) 
            {
                
            }

            if (viewModel.Password == viewModel.RepeatPassword) 
            {
                return View();
            }


            string passwordHash = viewModel.Password;
            

            var user = new User
            {
                Email = viewModel.Email,
                PasswordHash = passwordHash,
            };

            await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            return View();

        }

    }
}
