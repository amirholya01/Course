using System.ComponentModel.DataAnnotations;
using Courses.Web.Entities.Common;

namespace Courses.Web.Entities.Courses;

public class Course : BaseEntity
{
    #region properties

    [Required] [MaxLength(300)] public string Title { get; set; }

    [Required] [MaxLength(500)] public string ShortDescription { get; set; }

    [Required] public string Description { get; set; }

    [Required] [MaxLength(300)] public string Image { get; set; }

    public CourseType CourseType { get; set; }

    public bool IsActive { get; set; }

    #endregion

    #region relations

    public ICollection<CourseSession> CourseSessions { get; set; }

    #endregion
}