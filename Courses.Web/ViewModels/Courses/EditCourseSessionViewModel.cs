using System.ComponentModel.DataAnnotations;

namespace Courses.Web.ViewModels.Courses;

public class EditCourseSessionViewModel
{
    [Required] [MaxLength(300)] public string Title { get; set; }
    public string? AdditionalDescription { get; set; }
    public string? Text { get; set; }
    public IFormFile? Video { get; set; }
    public int DisplayOrder { get; set; }
}