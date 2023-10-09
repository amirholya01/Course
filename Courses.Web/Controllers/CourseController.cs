using Courses.Web.Repositories.Interfaces;
using Courses.Web.ViewModels.Courses;
using Microsoft.AspNetCore.Mvc;

namespace Courses.Web.Controllers;

[Route("courses")]
public class CourseController : Controller
{
    #region constructor

    private readonly ICourseRepository _courseRepository;

    public CourseController(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    #endregion
    
    #region courses list

    [Route("")]
    public async Task<IActionResult> CoursesList(FilterCoursesViewModel filter)
    {
        filter.Status = FilterCourseStatus.Active;
        filter.Type = FilterCourseType.All;
        return View(await _courseRepository.FilterCourses(filter));
    }

    #endregion

    #region course detail

    [Route("{courseId}/{courseName}")]
    public async Task<IActionResult> CourseDetail(int courseId, string courseName)
    {
        var course = await _courseRepository.GetCourseWithSessionsById(courseId);
        if (course == null) return NotFound();
        return View(course);
    }

    #endregion
}