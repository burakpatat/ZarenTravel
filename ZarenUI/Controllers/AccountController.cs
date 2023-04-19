using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ZarenUI.Models;
using DocumentFormat.OpenXml.Wordprocessing;
using Newtonsoft.Json;
using static BasketController;
using MongoDB.Bson;
using MongoDB.Driver;
using System.ComponentModel.DataAnnotations;
using Amazon.Runtime.Internal.Util;
using ZarenUI.Helper;
using Microsoft.Extensions.Caching.Distributed;
using DocumentFormat.OpenXml.InkML;

namespace ZarenUI.Controllers
{
    [Route("Account/[action]")]
    public partial class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IWebHostEnvironment env;
        private readonly IConfiguration configuration;
        private IDistributedCache _cache;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private MongoHelper _mongoClient;
        public AccountController(IWebHostEnvironment env, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager, IConfiguration _configuration, IHttpContextAccessor httpContextAccessor, IDistributedCache cache)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.env = env;
            configuration = _configuration;
            _httpContextAccessor = httpContextAccessor;
            _cache = cache;
            var connectionString = configuration.GetSection("MONGODB_URI");
            _mongoClient = new MongoHelper(_httpContextAccessor, configuration, _cache);

        }

        public class Root
        {
            [JsonProperty("User")]
            public AspNetUsers User { get; set; }
        }
        public class UploadResult
        {
            public bool Uploaded { get; set; }
            public string FileName { get; set; }
            public string StoredFileName { get; set; }
            public int ErrorCode { get; set; }
        }
	 

		[HttpPost("~/api/profile")]
        public ActionResult<string> ProfileUpdate([FromBody] Dictionary<string, object> User)
        {
            using (var context = new BookingReservationsRepository(configuration))
            {
                var cookie = _httpContextAccessor.HttpContext.Request.Cookies["ZtUser"];
                AspNetUsersRepository AspNetUsersRepository = new AspNetUsersRepository(configuration);
                var appUser = AspNetUsersRepository.GetUserByToken(cookie);
                if (appUser != null)
                {
                    string json = User.objectDictionaryToJson();
                    var myRoot = JsonConvert.DeserializeObject<Root>(json);

                    if (myRoot != null && myRoot != null)
                    {
                        var myUser = myRoot.User;
                        var UpdateInfo = new AspNetUsersRepository(configuration).Update(myUser);
                        if (UpdateInfo)
                        {
                            if (appUser != null)
                            {

                                appUser.FullName = myUser.FullName;
                                appUser.PhoneNumber = myUser.PhoneNumber;
                                appUser.Address = myUser.Address;
                                appUser.Email = myUser.Email;
                                appUser.Gender = myUser.Gender;
                                appUser.DateOfBirth = myUser.DateOfBirth;
                                appUser.CountryId = myUser.CountryId;
                                return appUser.ToJson();
                            }
                        }

                    }
                }
                _mongoClient.Log(appUser);

            }
            return "";
        }
        [HttpPost("~/api/AddToWishList")]
        public ActionResult<bool> AddToWishList([FromBody] Dictionary<string, object> json)
        {
            string jsonData = json.objectDictionaryToJson();
            var jsonModel = JsonConvert.DeserializeObject<dynamic>(jsonData);

            AspNetUsersRepository AspNetUsersRepository = new AspNetUsersRepository(configuration);
            var appUser = AspNetUsersRepository.GetByUserName(signInManager?.Context?.User?.Identity.Name).FirstOrDefault();

            var context = new AccountLikesRepository(configuration).GetByUserId(appUser.Id).Where(a => a.ProductId == jsonModel?.json?.id?.ToString()).FirstOrDefault();
            if (context == null)
            {
                var model = new AccountLikes()
                {
                    CookieId = appUser.Id,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    ProductId = jsonModel?.json?.id?.ToString(),
                    ProductType = "2",
                    UserId = appUser.Id
                };
                new AccountLikesRepository(configuration).Insert(model);
                return model.IsActive;
            }
            else
            {
                context.IsActive = !context.IsActive;
                new AccountLikesRepository(configuration).Update(context);
                return context.IsActive;
            }
        }

        [HttpGet("~/api/AddToWishList")]
        public ActionResult<string> AddWishListAfter()
        {
            AspNetUsersRepository AspNetUsersRepository = new AspNetUsersRepository(configuration);
            if (signInManager != null &&
                signInManager.Context != null &&
                signInManager.Context.User != null &&
                signInManager.Context.User.Identity != null &&
                signInManager.Context.User.Identity.Name != null)
            {
                var appUser = AspNetUsersRepository.GetByUserName(signInManager?.Context?.User?.Identity.Name).FirstOrDefault();
                if (appUser != null)
                {
                    var accountLike = new AccountLikesRepository(configuration).GetByUserId(appUser.Id).Where(a => a.IsActive == true);
                    return accountLike.ToJson();

                    _mongoClient.Log(accountLike);
                }
            }
            return null;

        }

        private IActionResult RedirectWithError(string error, string redirectUrl = null)
        {
            if (!string.IsNullOrEmpty(redirectUrl))
            {
                return Redirect($"~/Login?error={error}&redirectUrl={Uri.EscapeDataString(redirectUrl)}");
            }
            else
            {
                return Redirect($"~/Login?error={error}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            if (returnUrl != "/" && !string.IsNullOrEmpty(returnUrl))
            {
                return Redirect($"~/Login?redirectUrl={Uri.EscapeDataString(returnUrl)}");
            }

            return Redirect("~/Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password, string redirectUrl)
        {
            using (var repository = new AspNetUsersRepository(this.configuration))
            {
                if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
                {
                    var user = repository.GetByUserName(userName).FirstOrDefault();
                    if (user == null)
                        return RedirectWithError("Invalid user or password", redirectUrl);
                    if (!user.EmailConfirmed)
                        return RedirectWithError("User email not confirmed", redirectUrl);

                    var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, "webuser")
                };

                    roleManager.Roles.ToList().ForEach(r => claims.Add(new Claim(ClaimTypes.Role, r.Name)));
                    var result = await signInManager.PasswordSignInAsync(userName, password, false, false);

                    if (result.Succeeded)
                    {
                        var cookie = _httpContextAccessor.HttpContext.Request.Cookies["ZtUser"];
                        try
                        {
                            var row = repository.DeleteTokens(user.Id);
                            repository.InsertToken(new AspNetUserTokens()
                            {
                                UserId = user.Id,
                                LoginProvider = "Cookie",
                                Name = "ZtUser",
                                Value = cookie
                            });
                        }
                        catch
                        {

                        }
                        return Redirect($"~/{redirectUrl}");

                    }


                }
                return RedirectWithError("Invalid user or password", redirectUrl);
            }

        }

        public IActionResult FacebookLogin(string ReturnUrl)
        {
            try
            {
                string redirectUrl = Url.Action("ExternalResponse", "Account", new { ReturnUrl = ReturnUrl });
                AuthenticationProperties properties = signInManager.ConfigureExternalAuthenticationProperties("Facebook", redirectUrl);
                return new ChallengeResult("Facebook", properties);

            }
            catch (Exception)
            {

                throw;
            }

        }

        public IActionResult GoogleLogin(string ReturnUrl)
        {
            try
            {

                string redirectUrl = Url.Action("ExternalResponse", "Account", new { ReturnUrl = ReturnUrl });
                AuthenticationProperties properties = signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
                return new ChallengeResult("Google", properties);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<IActionResult> ExternalResponse(string redirectUrl)
        {
            using (AspNetUsersRepository repository = new AspNetUsersRepository(this.configuration))
            {
                ExternalLoginInfo loginInfo = await signInManager.GetExternalLoginInfoAsync();
                string mail = loginInfo.Principal.FindFirst(ClaimTypes.Email).Value;
                if (loginInfo == null)
                    return RedirectToAction("Login");
                else
                {
                    var user = repository.GetByEmail(mail).FirstOrDefault();
                    if (user != null)
                    {
                        if (loginInfo.LoginProvider == "Google")
                            user.GoogleId = loginInfo.ProviderKey;
                        else if (loginInfo.LoginProvider == "Facebook")
                            user.FacebookId = loginInfo.ProviderKey;

                        user.UpdateDate = DateTime.Now;
                        repository.Update(user);

                        var cookie = _httpContextAccessor.HttpContext.Request.Cookies["ZtUser"];

                        CookieOptions options = new CookieOptions();
                        options.Expires = loginInfo.AuthenticationProperties.ExpiresUtc;
                        _httpContextAccessor.HttpContext.Response.Cookies.Append("GoogleId", loginInfo.ProviderKey, options);

                        repository.InsertToken(new AspNetUserTokens()
                        {
                            UserId = user.Id,
                            LoginProvider = "Cookie",
                            Name = "ZtUser",
                            Value = cookie
                        });

                        repository.InsertToken(new AspNetUserTokens()
                        {
                            UserId = user.Id,
                            LoginProvider = "Google",
                            Name = "GoogleId",
                            Value = loginInfo.ProviderKey
                        });


                    } 

                    return Redirect($"~/{redirectUrl}");
                }
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePassword(string oldPassword, string newPassword)
        {
            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword))
            {
                return BadRequest("Invalid password");
            }

            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await userManager.FindByIdAsync(id);

            var result = await userManager.ChangePasswordAsync(user, oldPassword, newPassword);

            if (result.Succeeded)
            {
                return Ok();
            }

            var message = string.Join(", ", result.Errors.Select(error => error.Description));

            return BadRequest(message);
        }

        [HttpPost]
        public ApplicationAuthenticationState CurrentUser()
        {
            return new ApplicationAuthenticationState
            {
                IsAuthenticated = User.Identity.IsAuthenticated,
                Name = User.Identity.Name,
                Claims = User.Claims.Select(c => new ApplicationClaim { Type = c.Type, Value = c.Value })
            };
        }

        public async Task<IActionResult> Logout()
        {
            var cookie = _httpContextAccessor.HttpContext.Request.Cookies["ZtUser"];
            try
            {
                using (var repository = new AspNetUsersRepository(this.configuration))
                {
                    var row = repository.GetToken(cookie);
                    if (row != null)
                        repository.DeleteTokens(row.UserId);
                }
            }
            catch
            {

            }
            await signInManager.SignOutAsync();
            return Redirect("~/");
        }

        [HttpPost]
        public async Task<IActionResult> Register(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return Redirect("~/register?error=Invalid user name or password");
            }

            ApplicationUser user = new ApplicationUser
            {
                UserName = userName,
                Email = userName,
                Address = null,
                CountryId = 1,
                DateOfBirth = Convert.ToDateTime(DateTime.Now.ToShortDateTime()),
                FullName = null,
                Gender = 1,
                ProfilePhoto = "/images/user/usertravel.jpg"
            };

            var result = await userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                try
                {
                    var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code }, protocol: Request.Scheme);
                    var body = MailHelper.WelComeTemplate(user.Name, configuration.GetValue<string>("BaseUrl") + "/verify?u=" + user.Id + "&t=" + user.ConcurrencyStamp);
                    await SendEmailAsync(user.Email, "Confirm your registration", body);
                    return Redirect("~/login?info=Your registration has been confirmed");
                }
                catch (Exception ex)
                {
                    return Redirect("~/register?error=" + ex.Message);
                }
            }

            var message = string.Join(", ", result.Errors.Select(error => error.Description));

            return Redirect("~/register?error=" + message);
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            var user = await userManager.FindByIdAsync(userId);

            var result = await userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {
                return Redirect("~/Login?info=Your registration has been confirmed");
            }

            return RedirectWithError("Invalid user or confirmation code");
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(string userName)
        {
            try
            {
                var user = await userManager.FindByNameAsync(userName);
                if (user == null)
                { return RedirectWithError("Invalid user or password"); }
                var code = await userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action("ConfirmPasswordReset", "account", new { userId = user.Id, code }, protocol: Request.Scheme);
                var body = string.Format(@"<a href=""{0}"">{1}</a>", callbackUrl, "Please confirm your password reset.");
                await SendEmailAsync(user.Email, "Confirm your password reset", body);
                return Redirect("/sign-in?info=You will receive an email with your new password");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public async Task<IActionResult> ConfirmPasswordReset(string userId, string code)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
                return Redirect("~/Login?error=Invalid user");
            else
                return Redirect("~/resetpassword/" + userId + "?" + code);

        }
        [HttpPost]
        public async Task<IActionResult> ConfirmPasswordReset(string userId, string password, string passwordconfirm)
        {
            try
            {
                if (password == passwordconfirm)
                {
                    var user = await userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        string token = await userManager.GeneratePasswordResetTokenAsync(user);

                        var result = await userManager.ResetPasswordAsync(user, token, password);

                        if (result.Succeeded)
                        {
                            return Redirect("~/login?info=Password is Success");
                        }
                        else
                        {
                            string error = result.Errors.FirstOrDefault().Description.ToString();
                            return Redirect("~/resetpassword/" + userId + "?error=" + error);
                        }
                    }
                    else
                    {
                        return Redirect("~/Login?error=Invalid user or confirmation code");
                    }
                }
                else
                {
                    return Redirect("~/resetpassword/" + userId + "?error=Passwords do not match");
                }

            }
            catch (Exception ex)
            {
                return Redirect("~/resetpassword/?error=" + ex.Message.ToString());
            }
        }

        private static string GenerateRandomPassword()
        {
            var options = new PasswordOptions
            {
                RequiredLength = 8,
                RequiredUniqueChars = 4,
                RequireDigit = true,
                RequireLowercase = true,
                RequireNonAlphanumeric = true,
                RequireUppercase = true
            };

            var randomChars = new[] {
                "ABCDEFGHJKLMNOPQRSTUVWXYZ",
                "abcdefghijkmnopqrstuvwxyz",
                "0123456789",
                "!@$?_-"
            };

            var rand = new Random(Environment.TickCount);
            var chars = new List<char>();

            if (options.RequireUppercase)
            {
                chars.Insert(rand.Next(0, chars.Count), randomChars[0][rand.Next(0, randomChars[0].Length)]);
            }

            if (options.RequireLowercase)
            {
                chars.Insert(rand.Next(0, chars.Count), randomChars[1][rand.Next(0, randomChars[1].Length)]);
            }

            if (options.RequireDigit)
            {
                chars.Insert(rand.Next(0, chars.Count), randomChars[2][rand.Next(0, randomChars[2].Length)]);
            }

            if (options.RequireNonAlphanumeric)
            {
                chars.Insert(rand.Next(0, chars.Count), randomChars[3][rand.Next(0, randomChars[3].Length)]);
            }

            for (int i = chars.Count; i < options.RequiredLength || chars.Distinct().Count() < options.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count), rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }

        private async Task SendEmailAsync(string to, string subject, string body)
        {

            var mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.From = new System.Net.Mail.MailAddress(configuration.GetValue<string>("Smtp:User"));
            mailMessage.Body = body;
            mailMessage.Subject = subject;
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            mailMessage.IsBodyHtml = true;
            mailMessage.To.Add(to);

            var client = new System.Net.Mail.SmtpClient(configuration.GetValue<string>("Smtp:Host"))
            {
                UseDefaultCredentials = false,
                EnableSsl = configuration.GetValue<bool>("Smtp:Ssl"),
                Port = configuration.GetValue<int>("Smtp:Port"),
                Credentials = new System.Net.NetworkCredential(configuration.GetValue<string>("Smtp:User"), configuration.GetValue<string>("Smtp:Password"))
            };

            try
            {
                await client.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
        }
    }
}