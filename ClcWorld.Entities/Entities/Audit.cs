using System;

namespace ClcWorld.Entities.Entities
{
    public class Audit
    {
        public int Id { get; set; }
        public string EntityName { get; set; }
        public string EntityIdentifier { get; set; }
        public string Action { get; set; }
        public DateTime DateChanged { get; set; }
    }
}
