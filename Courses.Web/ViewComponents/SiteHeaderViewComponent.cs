using Microsoft.AspNetCore.Mvc;

namespace Courses.Web.ViewComponents;

public class SiteHeaderViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        ViewBag.ActionName = HttpContext.GetRouteData().Values["action"].ToString();
        ViewBag.ControllerName = HttpContext.GetRouteData().Values["controller"].ToString();
        return View("SiteHeader");
    }
}