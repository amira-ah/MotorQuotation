using Microsoft.EntityFrameworkCore;

namespace SystemCars.Data.Models
{
    public class DashboardData<T>
    {
        public DashboardData(List<T> items, int pageNumber,int pageSize,int dataQueryLimit)
        {
            Items = items;
            PageNumber = pageNumber;
            PageSize = pageSize;
            DataQueryLimit = dataQueryLimit;
        }
        public List<T> Items { get; set; }
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int DataQueryLimit { get; set; } = 5001;

        public static async Task<DashboardData<T>> CreateAsync(IQueryable<T> query, int page, int pagesize  )
        {
            var totalCount = await query.CountAsync();
            var items = await query.Skip((page - 1) * pagesize).Take(pagesize).ToListAsync();
            return new(items, page, pagesize, totalCount);
        }
    }
    public class MetadataColumDTO
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public MetadataColumDTO()
        {
            this.contextInfo = new Dictionary<string, object>();
        }

        /// <summary>
        /// Column Id. Should match with the property name in the dynamic result of data
        /// </summary>
        public string columnId { get; set; }

        /// <summary>
        /// Column Name. Friendly name of the column
        /// </summary>
        public string columnName { get; set; }

        /// <summary>
        /// Data type expected in string format
        /// </summary>
        public string columnType { get; set; }

        public Dictionary<string, object> contextInfo { get; set; }

        public int columnIndex { get; set; }

    }

}
