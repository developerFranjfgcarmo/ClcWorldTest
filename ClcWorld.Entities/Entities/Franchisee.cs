using System.Collections.Generic;

namespace ClcWorld.Entities.Entities
{
    public class Franchisee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}