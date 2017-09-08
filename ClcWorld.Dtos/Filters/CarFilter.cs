namespace ClcWorld.Dtos.Filters
{
    public class CarFilter:PageFilter
    {
        public string Registration { get; set; }
        public int? FranchiseeId { get; set; }
        public int? CarBrandId { get; set; }
        public int? Kilometers { get; set; }
    }
}
