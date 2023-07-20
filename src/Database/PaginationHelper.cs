using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace Database;

public class PagedRequest
{
    [DefaultValue(1)]
    public int? Page { get; set; } = 1;

    [DefaultValue(15)]
    public int? RowsPerPage { get; set; } = 15;
}

public class PagedResponse<T>
{
    public int CurrentPage { get; set; }
    public int PageCount { get; set; }
    public int RowsPerPage { get; set; }
    public int Total { get; set; }
    public IList<T> Rows { get; set; } = new List<T>();
}

public static class PaginationHelper
{
    public static async Task<PagedResponse<T>> ToPagedAsync<T>(
        this IQueryable<T> query,
        PagedRequest request,
        CancellationToken ct
    )
        where T : class
    {
        var page = request.Page ?? 1;
        var rowsPerPage = request.RowsPerPage ?? 15;
        var result = new PagedResponse<T>
        {
            CurrentPage = page,
            RowsPerPage = rowsPerPage,
            Total = await query.CountAsync(ct)
        };
        if (request.RowsPerPage == 0)
            request.RowsPerPage = result.Total;
        result.PageCount = result.Total / rowsPerPage;
        var skip = (page - 1) * rowsPerPage;
        result.Rows = await query.Skip(skip).Take(rowsPerPage).ToListAsync(ct);
        return result;
    }
}
