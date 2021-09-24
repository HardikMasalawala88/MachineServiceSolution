using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ModuleServicePOS.Data;
using ModuleServicePOS.Repository.Constant;
using ModuleServicePOS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleServicePOS.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserService _userService;
        private IConfiguration _config;
        private ApplicationContext _context;
        public AccountController(ILogger<AccountController> logger, IUserService userService, ApplicationContext context, IConfiguration config)
        {
            _logger = logger;
            _userService = userService;
            _context = context;
            _config = config;
        }
        public IActionResult Registration()
        {
            UserDetail user = new UserDetail();
            return View(user);
        }

        [HttpPost]
        public IActionResult Registration(UserDetail userDetails)
        {
            if (ModelState.IsValid)
            {
                userDetails.CreatedDate = DateTime.Now;
                _userService.InsertUser(userDetails);
            }
            return RedirectToAction("Login");
        }

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            UserDetail users = new UserDetail();
            return View(users);
        }

        [HttpPost]
        public IActionResult Login(UserDetail users)
        {
            if (users.UserName == null && users.Password != null)
            {
                TempData["errorMsg"] = "UserName Or Password Is Not Matched..!";
                return View();
            }
            else
            {
                var loggedInUser = _context.Users.Where(x => x.UserName == users.UserName && x.Password == users.Password)
                                                 .FirstOrDefault();
                if (loggedInUser != null)
                {
                    TempData["Msg"] = "Login Successfully..!";
                    HttpContext.Session.SetString(Constants.UserName, users.UserName);
                    HttpContext.Session.SetString(Constants.UName, loggedInUser.Name);
                    HttpContext.Session.SetString(Constants.UserId, loggedInUser.Id.ToString());
                }
                else
                {
                    TempData["errorMsg"] = "UserName Or Password Is Not Matched..!";
                    return View();
                }
                return RedirectToAction("Index", "Admin");
            }
        }
        #endregion

        #region Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Remove(Constants.UserName);
            ViewBag.Message = "User logged out successfully!";
            return RedirectToAction("Index","Home");
        } 
        #endregion
    }
}
