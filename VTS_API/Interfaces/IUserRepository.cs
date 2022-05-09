using System.Threading.Tasks;
using VTS_API.Models;

namespace VTS_API.Interfaces
{
    public interface IUserRepository
    {
        public Task AddUser(User user);
        public Task UpdateUser(User user);
        public Task<User> FindUserByUserID(int userID);
        public Task<bool> IsUserAlreadyExists(User user);
    }
}
