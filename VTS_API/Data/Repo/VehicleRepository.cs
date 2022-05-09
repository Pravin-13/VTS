using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VTS_API.Dtos;
using VTS_API.Interfaces;

namespace VTS_API.Data.Repo
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VTSDBContext dc;
        public VehicleRepository(VTSDBContext dc)
        {
            this.dc = dc;
        }
        public async Task<PagedResponseDto<List<VehicleListResDto>>> GetVehicleListAsync(PaginationFilterDto paginationFilter)
        {
            var validFilter = new PaginationFilterDto(paginationFilter.PageNumber, paginationFilter.PageSize);

            var pagedData = await this.dc.Vehicles.Select(v => new VehicleListResDto
            {
                VehicleNumber = v.VehicleNumber,
                VehicleType = v.VehicleType,
                ChassisNumber = v.ChassisNumber,
                EngineNumber = v.EngineNumber,
                ManufacturingYear = v.ManufacturingYear,
                LoadCarryingCapacity = v.LoadCarryingCapacity,
                MakeOfVehicle = v.MakeOfVehicle,
                ModelNumber = v.ModelNumber,
                BodyType = v.BodyType,
                OrganisationName = v.OrganisationName,
                User = v.User.Name,
                Device = v.Device.DeviceName
            })
            .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
            .Take(validFilter.PageSize)
            .ToListAsync();

            var totalRecords = await this.dc.Vehicles.CountAsync();

            var result = new PagedResponseDto<List<VehicleListResDto>>(pagedData, validFilter.PageNumber, validFilter.PageSize);

            return result;
        }
    }
}
