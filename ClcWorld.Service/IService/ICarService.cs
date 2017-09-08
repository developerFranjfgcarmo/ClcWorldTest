using System.Threading.Tasks;
using ClcWorld.Dtos;
using ClcWorld.Dtos.Filters;
using ClcWorld.Dtos.Models;
using ClcWorld.Entities.Entities;

namespace ClcWorld.Service.IService
{
    public interface ICarService 
    {
        Task<CarDto> AddOrUpdateCar(Car car);
        Task<CarDto> GetCarById(int id);
        Task<bool> DeleteCarById(int id);
        Task<PagedCollection<CarDto>> GetAll(CarFilter carFilter);
    }
}