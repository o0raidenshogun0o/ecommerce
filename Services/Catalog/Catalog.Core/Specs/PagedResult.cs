namespace Catalog.Core.Specs
{
    public class PagedResult<T> where T : class
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public long TotalItems { get; set; }
        public IReadOnlyList<T> Items { get; set; }

        public PagedResult()
        {
        }

        public PagedResult(int pageNumber, int pageSize, long totalItems, IReadOnlyList<T> items)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalItems = totalItems;
            Items = items;
        }
    }
}