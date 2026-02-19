namespace SortFilterPagination.Queries;

public class QueryParameters
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;

    public string? SearchTerm { get; set; }
    public string? City { get; set; }

    public string? SortColumn { get; set; } = "Id";
    public string? SortOrder { get; set; } = "asc";
}