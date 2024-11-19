using Microsoft.AspNetCore.Mvc;
using WebProgrammingAflevering.Data;
using WebProgrammingAflevering.Models.ViewModels;

namespace WebProgrammingAflevering.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public PostController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPostViewModel viewModel) 
        {
            
            


            return View(viewModel);
        }



    }
}
