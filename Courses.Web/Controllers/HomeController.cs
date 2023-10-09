using Microsoft.AspNetCore.Mvc;

namespace Courses.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}