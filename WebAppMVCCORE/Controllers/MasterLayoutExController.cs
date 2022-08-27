using Microsoft.AspNetCore.Mvc;
namespace WebAppMVCCORE.Controllers
{
    public class MasterLayoutExController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Landing()
        {
            return View();
        }

       
    }
}
