namespace ClcWorld.Dtos.Filters
{
    public class PageFilter
    {
        public int Take { get; set; }
        private int _skip;

        /// <summary>
        /// Number of Page
        /// </summary>
        public int Page
        {
            get
            {
                return _skip * Take;
            }
            set {
                _skip = value < 0 ? 0 : value;
            }
        }

        /// <summary>
        /// Name of the column to order by.
        /// </summary>
        public string OrderBy { get; set; }

        private string _orderDirection;

        /// <summary>
        /// Order direction. Value "ASC" for ascending (is database default), "DESC" for descending.
        /// </summary>
        public string OrderDirection
        {
            get
            {
                return _orderDirection?.ToLowerInvariant() == "desc" ? "DESC" : "ASC";
            }
            set { _orderDirection = value; }
        }
    }
}
