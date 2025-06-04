using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tech.Models;
using Tech.ModelView;

namespace Tech.Controllers
{
    public class TranieeController : Controller
    {
        TechContext _context = new TechContext();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CheckResult(int traineeId, int courseId)
        {
            var result = _context.crsResults
         .Include(r => r.Trainee)
         .Include(r => r.Course)
         .FirstOrDefault(r => r.TraineeID == traineeId && r.CrsId == courseId);

            if (result == null || result.Trainee == null || result.Course == null)
            {
                return Content("Result not found");
            }

            var status = result.Degree >= result.Course.MinDegree ? "Passed" : "Failed";
            var statusColor = status == "Passed" ? "green" : "red";

            var viewModel = new TraineeViewModel
            {
                Id = result.Id,
                TraineeName = result.Trainee.Name,
                CourseName = result.Course.Name,
                Degree = result.Degree,
                MinDegree = result.Course.MinDegree,
                Status = status,
                StatusColor = statusColor
            };

            return View(viewModel);
        }
    }
}
