using Courses.Web.Context;
using Courses.Web.Entities.Courses;
using Courses.Web.Repositories.Interfaces;
using Courses.Web.ViewModels.Courses;
using Microsoft.EntityFrameworkCore;

namespace Courses.Web.Repositories.Implementations;

public class CourseRepository : ICourseRepository
{
    private readonly ApplicationDbContext _context;

    public CourseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<FilterCoursesViewModel> FilterCourses(FilterCoursesViewModel filter)
    {
        var query = _context.Courses.AsQueryable();

        if (!string.IsNullOrEmpty(filter.Title))
            query = query.Where(c => EF.Functions.Like(c.Title, $"%{filter.Title}%") || EF.Functions.Like(c.Description, $"%{filter.Title}%"));

        switch (filter.Type)
        {
            case FilterCourseType.All:
                break;
            case FilterCourseType.Text:
                query = query.Where(c => c.CourseType == CourseType.Text);
                break;
            case FilterCourseType.Video:
                query = query.Where(c => c.CourseType == CourseType.Video);
                break;
        }

        switch (filter.Status)
        {
            case FilterCourseStatus.All:
                break;
            case FilterCourseStatus.Active:
                query = query.Where(c => c.IsActive);
                break;
            case FilterCourseStatus.NotActive:
                query = query.Where(c => !c.IsActive);
                break;
        }

        await filter.SetPaging(query);
        return filter;
    }

    public async Task<Course> CreateCourse(CreateCourseViewModel course, string imageName)
    {
        var newCourse = new Course()
        {
            Title = course.Title,
            Description = course.Description,
            ShortDescription = course.ShortDescription,
            CourseType = course.CourseType,
            IsActive = course.IsActive,
            Image = imageName
        };
        await _context.Courses.AddAsync(newCourse);
        await SaveChanges();
        return newCourse;
    }

    public async Task<EditCourseViewModel?> GetCourseForEdit(int courseId)
    {
        var course = await GetCourseById(courseId);
        if (course != null)
        {
            return new EditCourseViewModel
            {
                CourseId = courseId,
                Title = course.Title,
                Description = course.Description,
                ShortDescription = course.ShortDescription,
                CourseType = course.CourseType,
                IsActive = course.IsActive,
                ImageName = course.Image
            };
        }

        return null;
    }

    public async Task<Course?> GetCourseById(int courseId)
    {
        return await _context.Courses.SingleOrDefaultAsync(c => c.Id == courseId);
    }

    public async Task<Course?> GetCourseWithSessionsById(int courseId)
    {
        return await _context.Courses.Include(c => c.CourseSessions)
            .SingleOrDefaultAsync(c => c.Id == courseId);
    }

    public async Task<Course?> EditCourse(EditCourseViewModel course, string imageName)
    {
        var dbCourse = await GetCourseById(course.CourseId);
        if (dbCourse != null)
        {
            dbCourse.Title = course.Title;
            dbCourse.Description = course.Description;
            dbCourse.ShortDescription = course.ShortDescription;
            dbCourse.CourseType = course.CourseType;
            dbCourse.IsActive = course.IsActive;
            dbCourse.Image = imageName;

            _context.Courses.Update(dbCourse);
            await SaveChanges();

            return dbCourse;
        }

        return null;
    }

    public async Task<List<CourseSession>> GetAllCourseSessions(int courseId)
    {
        return await _context.CourseSessions.Where(c => c.CourseId == courseId).OrderBy(s => s.DisplayOrder).ToListAsync();
    }

    public async Task<CourseSession> CreateCourseSession(int courseId, CreateCourseSessionViewModel session, string videoFileName)
    {
        var newSession = new CourseSession()
        {
            Title = session.Title,
            CourseId = courseId,
            Text = session.Text,
            AdditionalDescription = session.AdditionalDescription,
            DisplayOrder = session.DisplayOrder,
            VideoFileName = videoFileName
        };

        await _context.CourseSessions.AddAsync(newSession);
        await SaveChanges();
        return newSession;
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}