using Assignment.Common;
using Assignment.Contract;
using Assignment.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment.BLL
{
    /// <summary>
    /// Implemenation of IUserService contract.
    /// </summary>
    public class ChatManager : IChatManager
    {
        private readonly IChatDalLayer _chatDalLayer;
        /// <summary>
        /// Create new instance of <see cref="UserManager"/> class.
        /// </summary>
        /// <param name="userDalLayer">User dal layer.</param>
        public ChatManager(IChatDalLayer chatDalLayer)
        {
            _chatDalLayer = chatDalLayer;
        }

        /// <summary>
        /// Authenticate user.
        /// </summary>
        /// <param name="userName">Username.</param>
        /// <param name="Password">Password.</param>
        /// <returns>Returns user id.</returns>
        public async Task<List<UserChat>> GetUserChat(UserChatDto model)
        {
            return await _chatDalLayer.GetUserChat(model);
        }

        public async Task<string> SaveUserChat(UserChat model)
        {
            return await _chatDalLayer.SaveUserChat(model);
        }
    }
}
