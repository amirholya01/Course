using Courses.Web.Entities.Courses;
using Courses.Web.ViewModels.Courses;

namespace Courses.Web.Repositories.Interfaces;

public interface ICourseRepository : IBaseRepository
{
    Task<FilterCoursesViewModel> FilterCourses(FilterCoursesViewModel filter);
    Task<Course> CreateCourse(CreateCourseViewModel course, string imageName);
    Task<EditCourseViewModel?> GetCourseForEdit(int courseId);
    Task<Course?> GetCourseById(int courseId);
    Task<Course?> GetCourseWithSessionsById(int courseId);
    Task<Course?> EditCourse(EditCourseViewModel course, string imageName);
    Task<List<CourseSession>> GetAllCourseSessions(int courseId);
    Task<CourseSession> CreateCourseSession(int courseId, CreateCourseSessionViewModel session, string videoFileName);
}