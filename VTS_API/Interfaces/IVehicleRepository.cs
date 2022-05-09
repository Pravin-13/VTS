using System.Collections.Generic;
using System.Threading.Tasks;
using VTS_API.Dtos;

namespace VTS_API.Interfaces
{
    public interface IVehicleRepository
    {
        public Task<PagedResponseDto<List<VehicleListResDto>>> GetVehicleListAsync(PaginationFilterDto paginationFilter);
    }
}
