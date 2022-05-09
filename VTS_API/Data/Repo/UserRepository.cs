using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using VTS_API.Interfaces;
using VTS_API.Models;

namespace VTS_API.Data.Repo
{
    public class UserRepository : IUserRepository
    {
        private readonly VTSDBContext dc;
        public UserRepository(VTSDBContext dc)
        {
            this.dc = dc;
        }
        public async Task AddUser(User user)
        {
            await this.dc.User.AddAsync(user);
        }
        public async Task<User> FindUserByUserID(int userID)
        {
            return await this.dc.User.Where(u => u.UserID == userID).FirstOrDefaultAsync();
        }
        public async Task<bool> IsUserAlreadyExists(User user)
        {
            if (user.UserID == 0)
                return await this.dc.User.Where(u => u.Name == user.Name).AnyAsync();
            else
                return await this.dc.User.Where(u => u.Name == user.Name && u.UserID != user.UserID).AnyAsync();
        }
        public async Task UpdateUser(User user)
        {
            await Task.Run(() => this.dc.User.Update(user));
        }
    }
}
