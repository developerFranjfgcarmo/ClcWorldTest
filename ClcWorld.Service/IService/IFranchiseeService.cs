using System.Threading.Tasks;
using ClcWorld.Dtos;
using ClcWorld.Dtos.Filters;
using ClcWorld.Dtos.Models;
using ClcWorld.Entities.Entities;

namespace ClcWorld.Service.IService
{
    public interface IFranchiseeService
    {
        Task<FranchiseeDto> AddOrUpdateFranchisee(Franchisee franchisee);
        Task<FranchiseeDto> GetFranchiseeById(int id);  
        Task<bool> DeleteFranchiseeById(int id);
        Task<PagedCollection<FranchiseeDto>> GetAll(FranchiseeFilter franchiseeFilter);
    }
}