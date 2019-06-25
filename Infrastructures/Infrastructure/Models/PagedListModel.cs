namespace Infrastructure.Models
{
    using System.Collections.Generic;
    using X.PagedList;

    /// <summary>
    /// PagedListModel
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    public class PagedListModel<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedListModel{T}"/> class.
        /// </summary>
        public PagedListModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedListModel{T}"/> class.
        /// </summary>
        /// <param name="pagedList">pagedList</param>
        public PagedListModel(IPagedList<T> pagedList)
        {
            Rows = pagedList;
            Total = pagedList.TotalItemCount;
        }

        /// <summary>
        /// Rows
        /// </summary>
        public IEnumerable<T> Rows { get; set; }

        /// <summary>
        /// Total
        /// </summary>
        public int Total { get; set; }
    }
}
