using Assignment.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment.Contract
{
    /// <summary>
    /// Contract for user service.
    /// </summary>
    public interface IChatManager
    {
        Task<List<UserChat>> GetUserChat(UserChatDto model);

        Task<string> SaveUserChat(UserChat model);
    }
}
