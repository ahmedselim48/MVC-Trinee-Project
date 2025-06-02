using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tech.Models;
using Tech.ModelView;

namespace Tech.Controllers
{
    public class InstructorController : Controller
    {
        TechContext Context = new TechContext();

        public IActionResult index(int page = 1)
        {
            int pageSize = 5;

            var query = Context.Instructors;

            int totalCount = query.Count();

            var instructors = query
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToList();


            foreach (var instructor in instructors)
            {
                Context.Entry(instructor).Reference(i => i.Course).Load();
                Context.Entry(instructor).Reference(i => i.Department).Load();
            }
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);


            return View("index", instructors);
        }
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var instructor = Context.Instructors.FirstOrDefault(i => i.Id == id);

            if (instructor == null) return NotFound();

            Context.Entry(instructor).Reference(i => i.Course).Load();
            Context.Entry(instructor).Reference(i => i.Department).Load();

            return View("Details", instructor);  
        }

       
        //public IActionResult Add() 
        //{
        //return View();
        //}

      
        public IActionResult Add()
        {
            var viewModel = new InstructorViewModel
            {
                Departments = Context.Departments
                    .Select(d => new SelectListItem
                    {
                        Value = d.Id.ToString(),
                        Text = d.Name
                    })
                    .ToList(),

                Courses = Context.Courses
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    })
                    .ToList()
            };

            return View("Add", viewModel);
        }



        [HttpPost]
        public IActionResult SaveAdd(InstructorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                foreach (var error in errors)
                {
                    Console.WriteLine("Validation error: " + error);
                }

                model.Departments = Context.Departments
                    .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
                    .ToList();

                model.Courses = Context.Courses
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                    .ToList();

                return View("Add", model);
            }

            var instructore = new Instructore
            {
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Salary = model.Salary,
                Address = model.Address,
                DeptId = model.DeptId,
                CrsId = model.CrsId
            };

            Context.Instructors.Add(instructore);
            Context.SaveChanges();

            return RedirectToAction("index");
        }


    }


}

