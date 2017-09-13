using ClcWorld.Dtos.Models;
using ClcWorld.Service.IService;
using ClcWorld.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace ClcWorld.WebApi.Controllers.MasterTables
{
    [RoutePrefix("api/v1/masterTables")]
    public class MasterTablesController : ApiController
    {
        private readonly IMasterTablesService _marterTablesService;
        private MasterTablesController(IMasterTablesService marterTablesService)
        {
            _marterTablesService = marterTablesService;
        }

        [HttpGet]
        [Route("CarBrand")]
        [ResponseType(typeof(List<SimpleDto>))]
        public async Task<IHttpActionResult> CarBrand()
        {
            var result = await _marterTablesService.GetCarBrand();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("Franchisee")]
        [ResponseType(typeof(List<SimpleDto>))]
        public async Task<IHttpActionResult> Franchisee()
        {
            var result = await _marterTablesService.GetFranchisee();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
