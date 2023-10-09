using System.ComponentModel.DataAnnotations;
using Courses.Web.Entities.Common;

namespace Courses.Web.Entities.Courses;

public class CourseSession : BaseEntity
{
    #region properties

    public int CourseId { get; set; }
    [Required] [MaxLength(300)] public string Title { get; set; }
    public string? AdditionalDescription { get; set; }
    public string? Text { get; set; }
    public string? VideoFileName { get; set; } 
    public int DisplayOrder { get; set; }

    #endregion

    #region relations

    public Course Course { get; set; }

    #endregion
}