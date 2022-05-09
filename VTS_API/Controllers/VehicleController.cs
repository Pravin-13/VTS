using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using VTS_API.Dtos;
using VTS_API.Helpers;
using VTS_API.Interfaces;

namespace VTS_API.Controllers
{
    public class VehicleController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly ILogger<VehicleController> logger;
        public VehicleController(IUnitOfWork uow, IMapper mapper, ILogger<VehicleController> logger)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet()]
        [Route("GetVehicleList")]
        public async Task<IActionResult> Get([FromQuery] PaginationFilterDto paginationFilter)
        {
            ResponseResultDto result = new();

            try
            {
                result.Data = await this.uow.VehicleRepository.GetVehicleListAsync(paginationFilter);
                result.MessageType = MessageConstant.Success;
                result.Message = MessageConstant.OK;
            }
            catch (Exception ex)
            {
                result.MessageType = MessageConstant.Error;
                result.Message = MessageConstant.Something_Went_Wrong;
                logger.Log(LogLevel.Error, ex.Message);
            }
            return Ok(result);
        }
    }
}
