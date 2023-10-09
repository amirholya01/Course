using Courses.Web.Entities.Courses;

namespace Courses.Web.ViewModels.Courses;

public class ShowCourseDetailViewModel
{
    public Course Course { get; set; }
    public List<CourseSession> CourseSessions { get; set; }
}