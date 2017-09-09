using AutoMapper;

namespace ClcWorld.Service.Mapping
{
    public class EntityToDtoProfile:Profile
    {
        public override string ProfileName => "EntityToModel";

        public EntityToDtoProfile()
        {
        }
    }
}
