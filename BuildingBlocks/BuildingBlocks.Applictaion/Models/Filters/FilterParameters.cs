using BuildingBlocks.Domain.Enums;

namespace BuildingBlocks.Applictaion.Models.Filters;
public class FilterParameters
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public OrderType OrderType { get; set; } = OrderType.Descending;
    public int Page { get; set; } = 0;
    public int PageSize { get; set; } = 20;

    public FilterParameters(DateTime start, DateTime end, OrderType orderType = default, int page = 0, int pageSize = 20)
    {
        Start = DateTime.SpecifyKind(start, DateTimeKind.Utc);
        End = DateTime.SpecifyKind(end, DateTimeKind.Utc);
        OrderType = orderType;
        Page = page;
        PageSize = pageSize;
    }
}