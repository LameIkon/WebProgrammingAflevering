﻿using Microsoft.AspNetCore.Mvc;
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


        [HttpGet, Authorize]
        public async Task<IActionResult> Index()
        {
            List<Post> posts = await _dbContext.Posts.ToListAsync<Post>();

            posts.Reverse();

            return View(posts);
        }


        [HttpGet, Authorize]
        public IActionResult Add()
        {
            return View();
        }

        const string xxsProtect = "<script>";

        [HttpPost, Authorize]
        public async Task<IActionResult> Add(AddPostViewModel viewModel) 
        {
            User user = await _dbContext.Users.Where(x => x.Username == HttpContext.User.Identity.Name).FirstOrDefaultAsync();
            
            if (ModelState.IsValid && user != null) {

                string stringFileName = UploadFile(viewModel);

                if (viewModel.Title != null)
                {
                    if (viewModel.Title.Contains(xxsProtect))
                    {
                        ViewBag.Message = $"A post cannot contain {xxsProtect}";
                        return View(viewModel);
                    }
                }
                if (viewModel.Description != null)
                {
                    if (viewModel.Description.Contains(xxsProtect))
                    {
                        ViewBag.Message = $"A post cannot contain {xxsProtect}";
                        return View(viewModel);
                    }
                }

                if (stringFileName != null) 
                {

                    if (stringFileName.Contains(xxsProtect))
                    {
                        ViewBag.Message = $"A post cannot contain {xxsProtect}";
                        return View(viewModel);
                    }

                    Post newPost = new Post();

                    newPost.Title = viewModel.Title;
                    newPost.Description = viewModel.Description;
                    newPost.Picture = stringFileName;
                    newPost.UserRefId = user.Id;

                    await _dbContext.AddAsync(newPost);
                    await _dbContext.SaveChangesAsync();

                    return RedirectToAction("Index");
                        
                }
            }

            return View(viewModel);
        }

        private readonly string jpg = ".jpg";
        private readonly string png = ".png";


        private string UploadFile(AddPostViewModel viewModel)
        {
            string fileName = null;
            if (viewModel.Picture != null)
            {
                string uploadDir = Path.Combine(_webHostEnvi.WebRootPath, _pictureDir);
                fileName = Guid.NewGuid().ToString() + "-" + viewModel.Picture.FileName;
                string extention = Path.GetExtension(fileName).ToLower();
                if (extention == jpg || extention == png)
                {
                    string filePath = Path.Combine(uploadDir, fileName);

                    using (FileStream stream = new FileStream(filePath, FileMode.Create))
                    {
                        viewModel.Picture.CopyTo(stream);
                    }
                }
                else
                {
                    fileName = null;
                }
            }

            return fileName;  
        }



    }
}
