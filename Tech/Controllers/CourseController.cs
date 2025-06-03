using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tech.Models;

namespace Tech.Controllers
{
    public class CourseController : Controller
    {
     

        
        TechContext Context = new TechContext();
        public IActionResult Index()
        {
            List<Course> coursesList = Context.Courses.ToList();
            return View("Index", coursesList);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.DepartmentList = new SelectList(Context.Departments.ToList(), "Id", "Name");
             return View("Add");
        }
        [HttpPost]
        public IActionResult SaveAdd(Course courseFromReq)
        {
            if(ModelState.IsValid)
            {
                Context.Courses.Add(courseFromReq);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentList = new SelectList(Context.Departments.ToList(), "Id", "Name");

            return View("Add", courseFromReq);
        }

        [HttpGet]
        public IActionResult CheckMinDegree(int minDegree, int degree)
        {
            if (minDegree < degree)
            {
                return Json(true); // valid
            }
            return Json("MinDegree must be less than Degree"); // invalid
        }






    }
}