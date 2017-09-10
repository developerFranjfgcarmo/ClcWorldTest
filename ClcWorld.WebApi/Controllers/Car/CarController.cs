using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ClcWorld.Dtos;
using ClcWorld.Dtos.Filters;
using ClcWorld.Dtos.Models;
using ClcWorld.Service.IService;
using ClcWorld.Utils.Extensions;
using ClcWorld.WebApi.Controllers.Car.ViewModels;

namespace ClcWorld.WebApi.Controllers.Car
{
  //todo:repasar http codes
  [RoutePrefix("api/v1")]
    public class CarController : ApiController
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        [Route("Cars")]
        [ResponseType(typeof(PagedCollection<CarDto>))]
        public async Task<IHttpActionResult> Get([FromUri]CarFilter carFilter)
        {
            if (carFilter == null)
            {
                return NotFound();
            }
            var result = await _carService.GetAll(carFilter);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // GET: api/Car/5
        [HttpGet]
        [Route("Cars/{id:int}")]
        [ResponseType(typeof(CarDto))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var result = await _carService.GetCarById(id);
            return result != null ? (IHttpActionResult) Ok(result) : NotFound();
        }

        // POST: api/Car
        [HttpPost]
        [Route("Cars")]
        [ResponseType(typeof(CarDto))]
        public async Task<IHttpActionResult> Post([FromBody]CarViewModel car)
        {
            var result = await _carService.AddOrUpdateCar(car.ToMap<Entities.Entities.Car>());
            if (result != null)
            {
                return Created(Request.RequestUri + result.Id.ToString(), result);
            }
            return Conflict();
        }

        // PUT: api/Car/5
        [HttpPut]
        [Route("Cars")]
        [ResponseType(typeof(CarDto))]
        public async Task<IHttpActionResult> Put(int id, [FromBody]CarViewModel car)
        {
            var currentCar = await _carService.GetCarById(id);
            if (currentCar == null)
            {
                return NotFound();
            }

            var result = await _carService.AddOrUpdateCar(car.ToMap<Entities.Entities.Car>());
            if (result != null)
            {
                return Ok(result);
            }
            return Content(HttpStatusCode.NoContent,car);
        }

        // DELETE: api/Car/5
        [HttpDelete]
        [Route("Cars")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            var result = await _carService.DeleteCarById(id);
            return result ?   Request.CreateResponse(HttpStatusCode.NoContent)
                : Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}
