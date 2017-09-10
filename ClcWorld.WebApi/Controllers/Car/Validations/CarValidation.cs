using ClcWorld.WebApi.Controllers.Car.ViewModels;
using FluentValidation;

namespace ClcWorld.WebApi.Controllers.Car.Validations
{
    public class CarValidation : AbstractValidator<CarViewModel>
    {
        public CarValidation()
        {
            RuleFor(r => r.FranchiseeId).NotEmpty().NotEqual(0)
                .WithMessage("Debe indicar un concesionario");
            RuleFor(r => r.CarBrandId).NotEmpty().NotEqual(0)
                .WithMessage("Debe indicar la marca del coche");
            RuleFor(r => r.Registration)
                .NotEmpty().WithMessage("La matrícula es obligatorioa")
                .Length(1, 10)
                .WithMessage("La longuitud máxima de la matrícula son 10 caracteres");
            RuleFor(r => r.Model)
                .NotEmpty()
                .WithMessage("El campo modelo es obligatorio")
                .Length(1, 80)
                .WithMessage("La longuitud máxima del campo modelo son 80 caracteres");
        }
    }
}