using System.Collections.Generic;

namespace ClcWorld.Entities.Entities
{
    public class CarBrand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
