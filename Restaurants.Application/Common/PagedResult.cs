namespace Restaurants.Application.Common
{
    public class PagedResult<T> where T : class
    {
        public PagedResult(IEnumerable<T> values,int TotalRecordCount,int PageNumber,int PageSize )
        {
            Items = values;
            this.TotalRecordCount = TotalRecordCount;
            TotalPages = (int)Math.Ceiling(TotalRecordCount / (double)PageSize);
            ItemsFrom = (PageNumber - 1) * PageSize + 1;
            ItemsTo = ItemsFrom + PageSize - 1;
        }

        public IEnumerable<T> Items { get; set; } = new List<T>();
        public int TotalRecordCount { get; }
        public int TotalPages { get; }

        public int ItemsFrom { get; }
        public int ItemsTo { get; }
    }
}
