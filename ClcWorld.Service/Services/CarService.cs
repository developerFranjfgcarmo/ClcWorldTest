using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using ClcWorld.Dtos;
using ClcWorld.Dtos.Filters;
using ClcWorld.Dtos.Models;
using ClcWorld.Entities.Context;
using ClcWorld.Entities.Entities;
using ClcWorld.Service.Helpers;
using ClcWorld.Service.IService;
using ClcWorld.Service.Queries;
using ClcWorld.Utils.Extensions;
using Dapper;

namespace ClcWorld.Service.Services
{
    public class CarService : ServiceBase, ICarService
    {
        public CarService(IClcWorldContext clcWorldContext) : base(clcWorldContext)
        {
        }

        #region [Commands]    
        
        public async Task<CarDto> AddOrUpdateCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }
            ClcWorldContext.Cars.AddOrUpdate(car);
            return await SaveAsync() ? car.ToMap<CarDto>() : null;
        }
       
        public async Task<bool> DeleteCarById(int id)
        {
            var car = new Car { Id = id };
            ClcWorldContext.Cars.Attach(car);
            ClcWorldContext.Cars.Remove(car);
            return await SaveAsync();
        }
        #endregion

        #region [Queries]      
        public async Task<CarDto> GetCarById(int id)
        {
            return (await ClcWorldContext.Cars.FindAsync(id))?.ToMap<CarDto>();
        }

        public async Task<PagedCollection<CarDto>> GetAll(CarFilter carFilter)
        {
            if (carFilter == null)
            {
                throw new ArgumentNullException(nameof(carFilter));
            }

            var whereClause = string.Empty;
            var orderByClause = "Order by ";

            if (!string.IsNullOrWhiteSpace(carFilter.Registration))
            {
                whereClause += whereClause.And(CarQuery.GetAllWhereRegistration);
            }
            if (carFilter.CarBrandId.HasValue)
            {
                whereClause += whereClause.And(CarQuery.GetAllWhereCarBrandId);
            }

            if (carFilter.FranchiseeId.HasValue)
            {
                whereClause += whereClause.And(CarQuery.GetAllWhereFranchiseeId);
            }
            if (carFilter.Kilometers.HasValue)
            {
                whereClause += whereClause.And(CarQuery.GetAllWhereKilometers);
            }

            if (string.IsNullOrWhiteSpace(carFilter.OrderBy))
            {
                orderByClause += "Id";
            }
            orderByClause += " " + carFilter.OrderDirection;

            var sql = string.Format(CarQuery.GetAll, whereClause, orderByClause);
            var result = new PagedCollection<CarDto>();
            using (var reader = await ClcWorldContext.Database.Connection.QueryMultipleAsync(sql, carFilter))
            {
                result.Items = (await reader.ReadAsync<CarDto>()).ToList();
                result.Total = (await reader.ReadAsync<int>()).FirstOrDefault();
            }

            return result; 
        }

        #endregion
        
    }
}