using ClcWorld.WebApi.Controllers.Franchisee.Validations;
using FluentValidation.Attributes;

namespace ClcWorld.WebApi.Controllers.Franchisee.ViewModels
{
    [Validator(typeof(FranchiseeValidation))]
    public class FranchiseeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AddressFranchisee { get; set; }
    }
}