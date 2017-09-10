using ClcWorld.WebApi.Controllers.Car.Validations;
using FluentValidation.Attributes;

namespace ClcWorld.WebApi.Controllers.Car.ViewModels
{
    [Validator(typeof(CarValidation))]
    public class CarViewModel
    {
        public int Id { get; set; }
        public string Registration { get; set; }
        public int FranchiseeId { get; set; }
        public int CarBrandId { get; set; }
        public int Kilometers { get; set; }
    }
}
