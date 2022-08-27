using Microsoft.AspNetCore.Mvc;
using WebAppMVCCORE.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace WebAppMVCCORE.Controllers
{
    public class AuthenExController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AuthenticModelClass obj)
        {
            if (string.IsNullOrEmpty(obj.UserName) && string.IsNullOrEmpty(obj.Password))
            {
                return RedirectToAction("Login");
            }
            ClaimsIdentity identity = null;
            bool isAuthentic = false;
            if (obj.UserName == "admin" && obj.Password == "admin")
            {
                identity = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Name,obj.UserName),
                    new Claim(ClaimTypes.Role,"Admin")
                    },
                     CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthentic = true;
            }
            if (obj.UserName == "user" && obj.Password == "user")
            {
                identity = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Name,obj.UserName),
                    new Claim(ClaimTypes.Role,"User")
                    },
                     CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthentic = true;
            }

            if (isAuthentic )
            {
                var principals = new ClaimsPrincipal(identity);
      var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principals);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
