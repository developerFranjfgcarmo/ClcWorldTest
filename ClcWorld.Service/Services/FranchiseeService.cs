using System;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using ClcWorld.Dtos;
using ClcWorld.Entities.Context;
using ClcWorld.Entities.Entities;
using ClcWorld.Service.IService;
using ClcWorld.Utils.Extensions;

namespace ClcWorld.Service.Services
{
    public class FranchiseeService : ServiceBase, IFranchiseeService
    {
        public FranchiseeService(IClcWorldContext clcWorldContext) : base(clcWorldContext)
        {
        }

        public async Task<FranchiseeDto> AddOrUpdateFranchisee(Franchisee franchisee)
        {
            if (franchisee == null)
            {
                throw new ArgumentNullException(nameof(franchisee));   
            }                
            ClcWorldContext.Franchisees.AddOrUpdate(franchisee);
            return await SaveAsync() ? franchisee.ToMap<FranchiseeDto>() : null;
        }

        public async Task<FranchiseeDto> GetFranchiseeById(int id)
        {
            return (await ClcWorldContext.Franchisees.FindAsync(id))?.ToMap<FranchiseeDto>();
        }

        public async Task<bool> DeleteFranchiseeById(int id)
        {
            var franchisee = new Franchisee {Id = id};
            ClcWorldContext.Franchisees.Attach(franchisee);
            ClcWorldContext.Franchisees.Remove(franchisee);
            return await SaveAsync();
        }
    }
}