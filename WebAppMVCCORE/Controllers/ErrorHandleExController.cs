using Microsoft.AspNetCore.Mvc;

namespace WebAppMVCCORE.Controllers
{
    public class ErrorHandleExController : Controller
    {
        [HttpGet]
        public IActionResult Index(string City)
        {
            if (City == "Hyd")
            {
                //   throw new Exception();
                ViewBag.error = "No City with Hyd";
                return RedirectToAction("Error", "Home");
            }
            else
            {
                ViewBag.data = City;
                return View();
            }
        }

        public IActionResult DivideByZero(int x, int y)
        {
            if (y == 0)
            {
                throw new Exception("No Data Found WIth this City");

            }
            else
            {
                int z = x / y;
                ViewBag.val = z;
                return View();
            }
        }
    }
}
