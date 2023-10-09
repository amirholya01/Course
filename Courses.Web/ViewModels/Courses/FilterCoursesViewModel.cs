using Courses.Web.Entities.Courses;
using Courses.Web.ViewModels.Pagination;

namespace Courses.Web.ViewModels.Courses;

public class FilterCoursesViewModel: Paging<Course>
{
    public string? Title { get; set; }

    public FilterCourseStatus Status { get; set; }

    public FilterCourseType Type { get; set; }
}

public enum FilterCourseStatus
{
    All,
    Active,
    NotActive
}

public enum FilterCourseType
{
    All,
    Video,
    Text
}