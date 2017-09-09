using System.Reflection;
using AutoMapper;
using ClcWorld.Service.Mapping;
using ClcWorld.WebApi.Mapping;
using log4net;

namespace ClcWorld.WebApi
{
    public static class AutoMappingConfig
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void Configuration()
        {
            Log.Info("Configure Automapping");

            Mapper.Initialize(i =>
            {
                i.AddProfile<ViewModelToEntityProfile>();
                i.AddProfile<EntityToDtoProfile>();
            });
        }
    }
}