using Microsoft.AspNetCore.Mvc;

namespace Courses.Web.Areas.Admin.ViewComponents;

public class AdminSidebarViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View("AdminSidebar");
    }
}