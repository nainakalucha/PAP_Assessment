using Assignment.Common;
using System.Threading.Tasks;

namespace Assignment.Contract
{
    /// <summary>
    /// Contract for user data layer.
    /// </summary>
    public interface IUserDalLayer
    {
        /// <summary>
        /// Authenticate user.
        /// </summary>
        /// <param name="userName">Username.</param>
        /// <param name="Password">Password.</param>
        /// <returns>Returns user id.</returns>
        Task<long?> AuthenticateUser(string userName, string Password);

        /// <summary>
        /// Get user by user id.
        /// </summary>
        /// <param name="userId">user id.</param>
        /// <returns>Returns user details.</returns>
        Task<UserLoginDto> GetById(long userId);
    }
}
