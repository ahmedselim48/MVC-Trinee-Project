using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Tech.Models;
using Tech.Repository;

namespace Tech.Controllers
{
    public class CourseController : Controller
    {
        ICourseRepository _courseRepository;
        IDepartmentRepository _departmentRepository;
        IInstructorRepository _instructorRepository;
        IResultRepository _resultRepository;



        //  TechContext Context = new TechContext();


        public CourseController(ICourseRepository CourseRepo , IDepartmentRepository departmentRepo, IInstructorRepository instructorRepository , IResultRepository resultRepository )
        {
            _courseRepository = CourseRepo;
            _departmentRepository = departmentRepo;
            _instructorRepository = instructorRepository;
            _resultRepository = resultRepository;
           
        }
        public IActionResult Index(string? searchName)
        {
            // var allCourse = Context.Courses.Include(c => c.Department).AsQueryable();
            var courses = _courseRepository.GetAll();

            if (!string.IsNullOrEmpty(searchName))
            {
                courses = courses.Where(c => c.Name.ToLower().Contains(searchName.ToLower()));
            }

            // List<Course> coursesList = Context.Courses.ToList();
            //  List<Course> coursesList = courses.ToList();
            var coursesList = courses.ToList();
            ViewBag.SearchName = searchName;
            return View("Index", coursesList);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.DepartmentList = new SelectList(_departmentRepository.GetAll(), "Id", "Name");
             return View("Add");
        }
        [HttpPost]
        public IActionResult SaveAdd(Course courseFromReq)
        {
            if(ModelState.IsValid)
            {
                _courseRepository.Add(courseFromReq);
                // Context.SaveChanges();
                _courseRepository.Save();

                return RedirectToAction("Index");
            }
            ViewBag.DepartmentList = new SelectList(_departmentRepository.GetAll(), "Id", "Name");

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
        public ActionResult Delete(int id)
        {
            //   var course = Context.Courses.FirstOrDefault(c => c.Id == id);
            var course = _courseRepository.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var course = _courseRepository.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            //  var relatedResults = Context.crsResults.Where(r => r.CrsId == id).ToList();
            //   Context.crsResults.RemoveRange(relatedResults);
            var relatedResults = _resultRepository.GetByCourseId(id);
            _resultRepository.RemoveRange(relatedResults);

            var relatedInstructors = _instructorRepository.GetByCourseId(id);
            _instructorRepository.RemoveRange(relatedInstructors);

            _courseRepository.Delete(id);
            // Context.SaveChanges();
            _courseRepository.Save();
            _resultRepository.Save();
            _instructorRepository.Save();
            return RedirectToAction("Index");
        }



    }
}