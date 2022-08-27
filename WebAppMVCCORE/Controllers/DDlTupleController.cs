using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppMVCCORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace WebAppMVCCORE.Controllers
{
    public class DDlTupleController : Controller
    {
        // GET: SchoolDetails  
        public ActionResult Index()
        {
            List<Departments> DeptList = new List<Departments>();  //List of Departments  
            List<Students> StudentList = new List<Students>();   // List of Students  
            DeptList.Add(new Departments
            {
                DeptId = 1,
                DeptName = "BCA"
            }); //adding list to DeptList Object  
            DeptList.Add(new Departments
            {
                DeptId = 2,
                DeptName = "BSC"
            });
            DeptList.Add(new Departments
            {
                DeptId = 3,
                DeptName = "MCA"
            });
            StudentList.Add(new Students
            {
                StudentId = 1,
                StudentName = "Ramesh"
            }); // adding list to StudentList Object  
            StudentList.Add(new Students
            {
                StudentId = 2,
                StudentName = "Kannan"
            });
            StudentList.Add(new Students
            {
                StudentId = 3,
                StudentName = "Vimal"
            });

            List<SelectListItem> DeptListNew = new List<SelectListItem>();  // Creating SelectListItem List  
            List<SelectListItem> StudentListNew = new List<SelectListItem>();
            DeptListNew = DeptList.Select(x => new SelectListItem
            {
                Text = x.DeptName,
                Value = x.DeptId.ToString()
            }).ToList(); //Binding DeptList to SelectListItem DeptListNew  
            StudentListNew = StudentList.Select(x => new SelectListItem
            {
                Text = x.StudentName,
                Value = x.StudentId.ToString()
            }).ToList(); //Binding StudentList to SelectListItem StudentListNew  


            var TubleList = Tuple.Create<List<SelectListItem>, List<SelectListItem>>(DeptListNew, StudentListNew); //creating Tuple and passing two select list item in that.  
            return View(TubleList); //passing Tuple to view.  
        }
    }
}
