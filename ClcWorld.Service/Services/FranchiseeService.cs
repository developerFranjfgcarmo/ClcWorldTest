using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using ClcWorld.Dtos;
using ClcWorld.Dtos.Filters;
using ClcWorld.Dtos.Models;
using ClcWorld.Entities.Context;
using ClcWorld.Entities.Entities;
using ClcWorld.Service.IService;
using ClcWorld.Utils.Extensions;
using Dapper;
using ClcWorld.Service.Helpers;
using ClcWorld.Service.Queries;

namespace ClcWorld.Service.Services
{
    public class FranchiseeService : ServiceBase, IFranchiseeService
    {
        public FranchiseeService(IClcWorldContext clcWorldContext) : base(clcWorldContext)
        {
        }

        #region [Queries]

         public async Task<PagedCollection<FranchiseeDto>> GetAll(FranchiseeFilter franchiseeFilter)
        {
            if (franchiseeFilter == null)
            {
                throw new ArgumentNullException(nameof(franchiseeFilter));
            }

            var whereClause = string.Empty;
            var orderByClause = "Order by ";
            if (!string.IsNullOrWhiteSpace(franchiseeFilter.AddressFranchisee))
            {
                whereClause += whereClause.And(FranchiseeQuery.GetAllWhereAddressFranchisee);
            }
            if (!string.IsNullOrWhiteSpace(franchiseeFilter.Name))
            {
                whereClause += whereClause.And(FranchiseeQuery.GetAllWhereName);
            }

            if (string.IsNullOrWhiteSpace(franchiseeFilter.OrderBy))
            {
                orderByClause += "Id" ;
            }
            orderByClause += " " + franchiseeFilter.OrderDirection;

            var sql = string.Format(FranchiseeQuery.GetAll, whereClause, orderByClause);
            var result=new  PagedCollection<FranchiseeDto>();
            using (var reader = await ClcWorldContext.Database.Connection.QueryMultipleAsync(sql, franchiseeFilter))
            {
                result.Items = (await reader.ReadAsync<FranchiseeDto>()).ToList();
                result.Total = (await reader.ReadAsync<int>()).FirstOrDefault();
            }

            return result;
        }

        #endregion

        #region [Commands]

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

        #endregion
      
    }
}