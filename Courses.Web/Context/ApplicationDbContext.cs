using Courses.Web.Entities.Courses;
using Microsoft.EntityFrameworkCore;

namespace Courses.Web.Context;

public class ApplicationDbContext : DbContext
{
    #region constructor

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    #endregion

    #region dbsets

    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseSession> CourseSessions { get; set; }

    #endregion
}