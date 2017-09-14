using ClcWorld.Dtos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClcWorld.Service.IService
{
    public interface IMasterTablesService
    {
        Task<List<SimpleDto>> GetCarBrand();
        Task<List<SimpleDto>> GetFranchisee();
    }
}
