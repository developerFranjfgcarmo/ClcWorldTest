using AutoMapper;
using ClcWorld.Dtos.Models;
using ClcWorld.Entities.Entities;

namespace ClcWorld.Service.Mapping
{
    public class EntityToDtoProfile:Profile
    {
        public override string ProfileName => "EntityToModel";

        public EntityToDtoProfile()
        {
            CreateMap<Car, CarDto>();
            CreateMap<Franchisee, FranchiseeDto>();
        }
    }
}
