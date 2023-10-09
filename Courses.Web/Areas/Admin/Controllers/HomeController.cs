using Microsoft.AspNetCore.Mvc;

namespace Courses.Web.Areas.Admin.Controllers;

public class HomeController : AdminBaseController
{
    public IActionResult Index()
    {
        return View();
    }
}