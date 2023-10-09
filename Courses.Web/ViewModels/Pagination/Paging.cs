using Microsoft.EntityFrameworkCore;

namespace Courses.Web.ViewModels.Pagination;

public class BasePaging
{
    public BasePaging()
    {
        Page = 1;
        Take = 10;
        PageTolerance = 5;
    }

    public int Page { get; set; }
    public int Take { get; set; }
    public int Skip { get; set; }
    public int StartPage { get; set; }
    public int EndPage { get; set; }
    public int PageTolerance { get; set; }
    public int PagesCount { get; set; }
    public int EntitiesCount { get; set; }

    public bool HasNextPage => Page < PagesCount;
    public int NextPage => Page + 1;
    public bool HasPreviousPage => Page > 1;
    public int PreviousPage => Page - 1;

    public BasePaging GetCurrentPaging()
    {
        return this;
    }
}

public class Paging<T> : BasePaging
{
    public List<T> Entities { get; set; } = new List<T>();

    public async Task SetPaging(IQueryable<T> query)
    {
        if (Take < 1) Take = 1;
        if (PageTolerance < 1) PageTolerance = 1;
        if (Page < 1) Page = 1;
        EntitiesCount = await query.CountAsync();
        PagesCount = (int)Math.Ceiling(EntitiesCount / (decimal)Take);
        if (Page > PagesCount && PagesCount > 0) Page = PagesCount;
        Skip = (Page - 1) * Take;
        StartPage = Page - PageTolerance < 1 ? 1 : Page - PageTolerance;
        EndPage = Page + PageTolerance > PagesCount ? PagesCount : Page + PageTolerance;
        Entities = await query.Skip(Skip).Take(Take).ToListAsync();
    }
}