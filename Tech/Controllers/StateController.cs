using Microsoft.AspNetCore.Mvc;

namespace Tech.Controllers
{
    public class StateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SetSession(string name)
        {
            HttpContext.Session.SetString("Name", name);
            HttpContext.Session.SetInt32("Salary",17000);
            return Content("Data Session Save");
        }

        public IActionResult GetSession(string name)
        {
           string _name = HttpContext.Session.GetString("Name");
            int? _Sal = HttpContext.Session.GetInt32("Salary");
            //HttpContext.Session.SetString("Name", name);
            //HttpContext.Session.SetInt32("Salary", 17000);
            return Content($"Name {_name} : Salary {_Sal}");
        }

        public IActionResult SetCookie(string name, int Salary)
        {
            //Session Cookie
            HttpContext.Response.Cookies.Append("Name", name);
            //Presistent Cookie
            CookieOptions options = new CookieOptions();
            options.Expires = DateTimeOffset.Now.AddDays(1);

            HttpContext.Response.Cookies.Append("Salary", Salary.ToString(), options);
            return Content("Cookie Saved");
        }

        public IActionResult GetCookie()
        {
            //logic
            string _name = HttpContext.Request.Cookies["Name"];
            string _Sal = HttpContext.Request.Cookies["Salary"];
            return Content($"Cookie {_name}\n {_Sal}");

        }

    }
}
