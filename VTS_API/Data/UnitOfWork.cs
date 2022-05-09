using System.Threading.Tasks;
using VTS_API.Data.Repo;
using VTS_API.Interfaces;

namespace VTS_API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VTSDBContext dc;
        public UnitOfWork(VTSDBContext dc)
        {
            this.dc = dc;
        }
        public IUserRepository UserRepository => new UserRepository(this.dc);
        public IVehicleRepository VehicleRepository => new VehicleRepository(this.dc);
        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}
