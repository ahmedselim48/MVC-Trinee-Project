using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Tech.Models;

namespace Tech.Controllers
{
    public class CourseController : Controller
    {
     

        
        TechContext Context = new TechContext();
        public IActionResult Index(string? searchName)
        {
            var allCourse = Context.Courses.Include(c => c.Department).AsQueryable();
           if(!string.IsNullOrEmpty(searchName))
            {
                allCourse= allCourse.Where(c => c.Name.ToLower().Contains(searchName.ToLower()));
            }

           // List<Course> coursesList = Context.Courses.ToList();
            List<Course> coursesList = allCourse.ToList();
            ViewBag.SearchName = searchName;
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


        // GET: /Course/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var course = Context.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var course = Context.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return NotFound();
            }
            var relatedResults = Context.crsResults.Where(r => r.CrsId == id).ToList();
            Context.crsResults.RemoveRange(relatedResults);

            var relatedInstructors = Context.Instructors.Where(i => i.CrsId == id).ToList();
            Context.Instructors.RemoveRange(relatedInstructors);

            Context.Courses.Remove(course);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}