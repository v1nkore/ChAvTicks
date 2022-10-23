namespace ChAvTicks.Application.Requests.Pagination
{
    public sealed class SearchFlightsPaginationRequest
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}