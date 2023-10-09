﻿using System.ComponentModel.DataAnnotations;
using Courses.Web.Entities.Courses;

namespace Courses.Web.ViewModels.Courses;

public class EditCourseViewModel
{
    public int CourseId { get; set; }
    public string ImageName { get; set; }
    [Required] [MaxLength(300)] public string Title { get; set; }

    [Required] [MaxLength(500)] public string ShortDescription { get; set; }

    [Required] public string Description { get; set; }

    public IFormFile? Image { get; set; }

    public CourseType CourseType { get; set; }

    public bool IsActive { get; set; }
}