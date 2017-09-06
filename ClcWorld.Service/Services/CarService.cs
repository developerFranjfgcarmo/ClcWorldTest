using System.Threading.Tasks;
using ClcWorld.Entities.Context;
using ClcWorld.Entities.Entities;
using ClcWorld.Service.IService;

namespace ClcWorld.Service.Services
{
    public class CarService : ServiceBase, ICarService
    {
        public CarService(IClcWorldContext clcWorldContext) : base(clcWorldContext)
        {
        }

        public Task<Car> AddOrUpdateFranchisee(Car franchisee)
        {
            throw new System.NotImplementedException();
        }

        public Task<Car> GetFranchiseeById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteFranchiseeById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}