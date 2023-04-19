using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using ZarenUI.Models;
using Microsoft.Extensions.Configuration;


namespace ZarenUI.Controllers
{
    public partial class UploadController : Controller
    {
        private IConfiguration _configuration;
        private readonly IWebHostEnvironment environment;
        private readonly SignInManager<ApplicationUser> signInManager;
        public UploadController(IConfiguration configuration, IWebHostEnvironment environment, SignInManager<ApplicationUser> signInManager)
        {
            _configuration = configuration;
            this.signInManager = signInManager;
            this.environment = environment;
        }

        [HttpPost("upload/imageUpload")]
        public async Task<IActionResult> ImageUpload(IFormFile imageFile,string userId)
        {
            string url = "/account-profile";
            try
            {
                AspNetUsersRepository AspNetUsersRepository = new AspNetUsersRepository(_configuration);
                var user = AspNetUsersRepository.GetByID(userId);
                if (user!=null && imageFile != null)            
                {
                                  
                    AspNetUsers appUser = AspNetUsersRepository.GetByUserName(user.UserName).FirstOrDefault();
                    if (appUser != null)
                    {
                        string guid = Guid.NewGuid().ToString();
                        string fileName = Path.GetExtension(imageFile.FileName);
                        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\user", guid + fileName);
                        using FileStream stream = new(filePath, FileMode.Create);
                        await imageFile.CopyToAsync(stream);
                        string filePathfirst = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" + appUser.ProfilePhoto);
                        if (System.IO.File.Exists(filePathfirst))
                        {
                            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/user/usertravel.jpg");

                            if (filePathfirst != path)
                            {
                                System.IO.File.Delete(filePathfirst);
                            }
                        }
                        appUser.ProfilePhoto = "/images/user/" + guid + fileName;
                        new AspNetUsersRepository(_configuration).Update(appUser);

                        return new RedirectResult(url, true);
                    }
                }
                url += "?error";
                return new RedirectResult(url + "?error", true);
            }
            catch (Exception ex)
            {
                return new RedirectResult(url + "?error=" + ex.Message, true);
            }
        }
        // Single file upload
        [HttpPost("upload/single")]
        public IActionResult Single(IFormFile file)
        {
            try
            {
                // Put your code here
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Multiple files upload
        [HttpPost("upload/multiple")]
        public IActionResult Multiple(IFormFile[] files)
        {
            try
            {
                // Put your code here
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Multiple files upload with parameter
        [HttpPost("upload/{id}")]
        public IActionResult Post(IFormFile[] files, int id)
        {
            try
            {
                // Put your code here
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Image file upload (used by HtmlEditor components)
        [HttpPost("upload/image")]
        public IActionResult Image(IFormFile file)
        {
            try
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

                using (var stream = new FileStream(Path.Combine(environment.WebRootPath, fileName), FileMode.Create))
                {
                    // Save the file
                    file.CopyTo(stream);

                    // Return the URL of the file
                    var url = Url.Content($"~/{fileName}");

                    return Ok(new { Url = url });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
