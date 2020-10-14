using Assignment.Common;
using Assignment.Contract;
using Assignment.Model;
using System.Threading.Tasks;

namespace Assignment.BLL
{
    /// <summary>
    /// Implemenation of IUserService contract.
    /// </summary>
    public class UserManager : IUserManager
    {
        private readonly IUserDalLayer _userDalLayer;

        /// <summary>
        /// Create new instance of <see cref="UserManager"/> class.
        /// </summary>
        /// <param name="userDalLayer">User dal layer.</param>
        public UserManager(IUserDalLayer userDalLayer)
        {
            _userDalLayer = userDalLayer;
        }

        /// <summary>
        /// Authenticate user.
        /// </summary>
        /// <param name="userName">Username.</param>
        /// <param name="Password">Password.</param>
        /// <returns>Returns user id.</returns>
        public async Task<long?> AuthenticateUser(string userName, string Password)
        {
            return await _userDalLayer.AuthenticateUser(userName, Password);
        }

        /// <summary>
        /// Get user by user id.
        /// </summary>
        /// <param name="userId">user id.</param>
        /// <returns>Returns user details.</returns>
        public async Task<UserLoginDto> GetById(long userId)
        {
            return await _userDalLayer.GetById(userId);
        }
    }
}
