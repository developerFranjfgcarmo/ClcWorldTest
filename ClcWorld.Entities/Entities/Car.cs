namespace ClcWorld.Entities.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Registration { get; set; }
        public string Model { get; set; }
        public int FranchiseeId { get; set; }
        public int CarBrandId { get; set; }
        public int Kilometers { get; set; }
        public virtual CarBrand CarBrand { get; set; }
        public virtual Franchisee Franchisee { get; set; }
    }
}
