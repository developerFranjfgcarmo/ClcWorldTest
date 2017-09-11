using AutoMapper;
using ClcWorld.Entities.Entities;
using ClcWorld.WebApi.Controllers.Car.ViewModels;
using ClcWorld.WebApi.Controllers.Franchisee.ViewModels;

namespace ClcWorld.WebApi.Mapping
{
    public class ViewModelToEntityProfile : Profile
    {       
        public override string ProfileName => "ViewModelToEntity";
        public ViewModelToEntityProfile()
        {
            CreateMap<CarViewModel, Car>();
            CreateMap<FranchiseeViewModel, Franchisee>();
        }
    }
}