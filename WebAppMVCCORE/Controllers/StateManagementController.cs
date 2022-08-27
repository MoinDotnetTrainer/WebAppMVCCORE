using Microsoft.AspNetCore.Mvc;
using WebAppMVCCORE.Models;

namespace WebAppMVCCORE.Controllers
{
    public class StateManagementController : Controller
    {
        [HttpGet]
        public IActionResult SetValues()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetValues(StateManagementModelEx obj)
        {
            HttpContext.Session.SetString("userName", obj.UserName);
            return RedirectToAction("GetValues");
        }

        [HttpGet]
        public IActionResult GetValues()
        {
            if (HttpContext.Session.GetString("userName") == null)
            {
                return RedirectToAction("SetValues");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        [TestFilter]
        public IActionResult SetSessionGlobally()
        {

            return View();

        }
    }
}
