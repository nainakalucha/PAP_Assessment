using Assignment.Common;
using Assignment.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment.Contract
{
    /// <summary>
    /// Contract for user data layer.
    /// </summary>
    public interface IChatDalLayer
    {
        Task<List<UserChat>> GetUserChat(UserChatDto model);

        Task<string> SaveUserChat(UserChat model);
    }
}
