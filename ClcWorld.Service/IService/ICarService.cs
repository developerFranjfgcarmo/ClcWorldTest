using System.Threading.Tasks;
using ClcWorld.Dtos;
using ClcWorld.Entities.Entities;

namespace ClcWorld.Service.IService
{
    public interface ICarService 
    {
        Task<Car> AddOrUpdateFranchisee(Car franchisee);
        Task<Car> GetFranchiseeById(int id);
        Task<bool> DeleteFranchiseeById(int id);
    }
}