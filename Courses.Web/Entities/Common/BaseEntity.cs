using System.ComponentModel.DataAnnotations;

namespace Courses.Web.Entities.Common;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }
}