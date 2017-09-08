namespace ClcWorld.Dtos.Models
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Registration { get; set; }
        public int FranchiseeId { get; set; }
        public int CarBrandId { get; set; }
        public int Kilometers { get; set; }
    }
}
