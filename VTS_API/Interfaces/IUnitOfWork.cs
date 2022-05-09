using System.Threading.Tasks;

namespace VTS_API.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IVehicleRepository VehicleRepository { get; }
        Task<bool> SaveAsync();
    }
}
