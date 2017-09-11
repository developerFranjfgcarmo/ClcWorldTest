using System.Collections.Generic;

namespace ClcWorld.Dtos
{
    /// <summary>
    /// Represents a paged result collection
    /// </summary>
    /// <typeparam name="TDto">Dto</typeparam>
    public class PagedCollection<TDto>
    {
        public List<TDto> Items { get;  set; }
        public int Total { get; set; }
    }
}
