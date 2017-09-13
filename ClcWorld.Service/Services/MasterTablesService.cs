using ClcWorld.Service.IService;
using ClcWorld.Dtos.Models;
using ClcWorld.Entities.Context;
using System.Linq;
using System.Collections.Generic;
using Dapper;
using ClcWorld.Service.Queries;
using System.Threading.Tasks;

namespace ClcWorld.Service.Services
{
    //todo: save in cache
    public class MasterTablesService : ServiceBase, IMasterTablesService
    {
        public MasterTablesService(IClcWorldContext clcWorldContext) : base(clcWorldContext)
        {
        }
        
        public async Task<List<SimpleDto>> GetCarBrand()
        {
          return (await ClcWorldContext.Database.Connection.QueryAsync<SimpleDto>(MasterTablesQuery.GetCarBrand)).ToList();
        }

        public async Task<List<SimpleDto>> GetFranchisee()
        {
            return (await ClcWorldContext.Database.Connection.QueryAsync<SimpleDto>(MasterTablesQuery.GetFranchisees)).ToList();
        }
    }
}
