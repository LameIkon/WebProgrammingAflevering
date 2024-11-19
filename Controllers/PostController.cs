using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Net;
using WebProgrammingAflevering.Data;
using WebProgrammingAflevering.Models.ViewModels;
using WebProgrammingAflevering.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace WebProgrammingAflevering.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _webHostEnvi;
        private readonly string _pictureDir = "Images";



        public PostController(ApplicationDbContext dbContext, IWebHostEnvironment webHostEnvi)
        {
            _dbContext = dbContext;
            _webHostEnvi = webHostEnvi;
        }


        public async Task<IActionResult> Index()
        {
            List<Post> posts = await _dbContext.Posts.ToListAsync<Post>();

            return View(posts);
        }


        [HttpGet, Authorize]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> Add(AddPostViewModel viewModel) 
        {
            User user = await _dbContext.Users.Where(x => x.Username == HttpContext.User.Identity.Name).FirstOrDefaultAsync();
            
            if (ModelState.IsValid && user != null) {

                string stringFileName = UploadFile(viewModel);

                if (stringFileName != null) 
                { 
                
                    Post newPost = new Post();

                    newPost.Title = viewModel.Title;
                    newPost.Description = viewModel.Description;
                    newPost.Picture = stringFileName;
                    newPost.UserRefId = user.Id;

                    await _dbContext.AddAsync(newPost);
                    await _dbContext.SaveChangesAsync();

                    return RedirectToAction("Index", "Home");
                        
                }
            }

            return View(viewModel);
        }


        private string UploadFile(AddPostViewModel viewModel) 
        {
            string fileName = null;
            if (viewModel.Picture != null) 
            {
                string uploadDir = Path.Combine(_webHostEnvi.WebRootPath, _pictureDir);
                fileName = Guid.NewGuid().ToString() + "-" + viewModel.Picture.FileName;
                string filePath = Path.Combine(uploadDir, fileName);

                using (FileStream stream = new FileStream(filePath, FileMode.Create)) 
                {
                    viewModel.Picture.CopyTo(stream);
                }
            }

            return fileName;
            
        }



    }
}
