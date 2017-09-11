using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClcWorld.Service.IService;
using ClcWorld.Dtos.Models;
using ClcWorld.Dtos;
using ClcWorld.Dtos.Filters;
using ClcWorld.WebApi.Controllers.Franchisee.ViewModels;
using System.Web.Http.Description;
using System.Threading.Tasks;
using ClcWorld.Utils.Extensions;

namespace ClcWorld.WebApi.Controllers.Franchisee
{
    [RoutePrefix("api/v1")]
    public class FranchiseeController : ApiController
    {
        private readonly IFranchiseeService _franchiseeService;

        public FranchiseeController(IFranchiseeService franchiseeService)
        {
            _franchiseeService = franchiseeService;
        }

        [HttpGet]
        [Route("Franchisees")]
        [ResponseType(typeof(PagedCollection<FranchiseeDto>))]
        public async Task<IHttpActionResult> Get([FromUri]FranchiseeFilter franchiseeFilter)
        {
            if (franchiseeFilter == null)
            {
                return NotFound();
            }
            var result = await _franchiseeService.GetAll(franchiseeFilter);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("Franchisees/{id:int}")]
        [ResponseType(typeof(FranchiseeDto))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var result = await _franchiseeService.GetFranchiseeById(id);
            return result != null ? (IHttpActionResult)Ok(result) : NotFound();
        }
        
        [HttpPost]
        [Route("Franchisees")]
        [ResponseType(typeof(FranchiseeDto))]
        public async Task<IHttpActionResult> Post([FromBody]FranchiseeViewModel franchisee)
        {
            var result = await _franchiseeService.AddOrUpdateFranchisee(franchisee.ToMap<Entities.Entities.Franchisee>());
            if (result != null)
            {
                return Created(Request.RequestUri + result.Id.ToString(), result);
            }
            return Conflict();
        }

        [HttpPut]
        [Route("Franchisees")]
        [ResponseType(typeof(FranchiseeDto))]
        public async Task<IHttpActionResult> Put(int id, [FromBody]FranchiseeViewModel franchisee)
        {
            var currentCar = await _franchiseeService.GetFranchiseeById(id);
            if (currentCar == null)
            {
                return NotFound();
            }

            var result = await _franchiseeService.AddOrUpdateFranchisee(franchisee.ToMap<Entities.Entities.Franchisee>());
            if (result != null)
            {
                return Ok(result);
            }
            return Content(HttpStatusCode.NoContent, franchisee);
        }

        [HttpDelete]
        [Route("Franchisees")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            var result = await _franchiseeService.DeleteFranchiseeById(id);
            return result ? Request.CreateResponse(HttpStatusCode.NoContent)
                : Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}
