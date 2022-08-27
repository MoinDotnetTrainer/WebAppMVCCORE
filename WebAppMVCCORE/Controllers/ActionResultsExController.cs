using Microsoft.AspNetCore.Mvc;

namespace WebAppMVCCORE.Controllers
{
    public class ActionResultsExController : Controller
    {
        public IActionResult Index()
        {
            //same Controller
            //return RedirectToAction("Index1");

            //other controller
            return RedirectToAction("GetData","Orders");
        }

        public IActionResult Partial()
        {
            ViewBag.data1 = "Hello";
            return PartialView("_PartialLAyout");
        }

        public IActionResult Index1()
        {
            return Content("No Data  at Index1");
        }

        public IActionResult Index2()
        {
            return Content("No Data Index 2");
        }

        [HttpGet]
        public ActionResult ViewDataEx()
        {
            List<string> StaffInfo = new List<string>();
            StaffInfo.Add("Lineka ViewDataEx");
            StaffInfo.Add("Demin ViewDataEx");
            ViewData["StaffInfo"] = StaffInfo;
            return View();
        }

        [HttpGet]
        public ActionResult ViewbagEx()
        {
            List<string> StaffInfo = new List<string>();
            StaffInfo.Add("Lineka ViewbagEx");
            StaffInfo.Add("Demin ViewbagEx");
            ViewBag.StaffInfo = StaffInfo;
            return View();
        }

        [HttpGet]
        public ActionResult Tempdata()
        {
            List<string> StaffInfo = new List<string>();
            StaffInfo.Add("Lineka Tempdata");
            StaffInfo.Add("Demin Tempdata");
            TempData["StaffInfo"] = StaffInfo;
            return RedirectToAction("Index","Home");
        }
    }
}
