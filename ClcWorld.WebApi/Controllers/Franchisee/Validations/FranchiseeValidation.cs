using ClcWorld.WebApi.Controllers.Franchisee.ViewModels;
using FluentValidation;

namespace ClcWorld.WebApi.Controllers.Franchisee.Validations
{
    public class FranchiseeValidation:AbstractValidator<FranchiseeViewModel>
    {
        public FranchiseeValidation()
        {
            RuleFor(r => r.AddressFranchisee)
                .Length(0, 100)
                .WithMessage("La longuitud máxima de la dirección son 100 caracteres");
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("El nombre es obligatorioa")
                .Length(1, 5)
                .WithMessage("La longuitud máxima del nombre son 50 caracteres");
        }
    }
}