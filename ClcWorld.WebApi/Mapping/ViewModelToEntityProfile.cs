using AutoMapper;

namespace ClcWorld.WebApi.Mapping
{
    public class ViewModelToEntityProfile : Profile
    {       
        public override string ProfileName => "ViewModelToEntity";
        public ViewModelToEntityProfile()
        {
            //CreateMap<Car>()
        }
    }
}