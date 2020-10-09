using Assignment.Common;
using Assignment.Contract;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.DAL
{
    /// <summary>
    /// Implemenation of IUserDalLayer contract.
    /// </summary>
    public class UserDalLayer : IUserDalLayer
    {        
        private readonly SqlDbContext _dbContext;

        /// <summary>
        /// Create new instance of <see cref="UserDalLayer"/> class.
        /// </summary>
        /// <param name="dBContext">Db context.</param>
        public UserDalLayer(SqlDbContext dBContext)
        {
            _dbContext = dBContext;
        }

        /// <summary>
        /// Authenticate user.
        /// </summary>
        /// <param name="userName">Username.</param>
        /// <param name="Password">Password.</param>
        /// <returns>Returns user id.</returns>
        public async Task<long?> AuthenticateUser(string userName, string password)
        {
            var user = await _dbContext.UserLogin.Where(p => p.Username == userName && p.Password == password).SingleOrDefaultAsync();
            if (null == user) return null;
            return user.Id;
        }

        /// <summary>
        /// Get user by user id.
        /// </summary>
        /// <param name="userId">user id.</param>
        /// <returns>Returns user details.</returns>
        public async Task<UserLoginDto> GetById(long userId)
        {
            var user = await _dbContext.UserLogin.Where(p => p.Id == userId).SingleOrDefaultAsync();
            if (null == user) return null;
            return new UserLoginDto { Id = user.Id, Username = user.Username };
        }
    }
}
