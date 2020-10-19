using Assignment.Common;
using Assignment.Contract;
using Assignment.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.DAL
{
    /// <summary>
    /// Implemenation of IUserDalLayer contract.
    /// </summary>
    public class ChatDalLayer : IChatDalLayer
    {        
        private readonly SqlDbContext _dbContext;

        /// <summary>
        /// Create new instance of <see cref="UserDalLayer"/> class.
        /// </summary>
        /// <param name="dBContext">Db context.</param>
        public ChatDalLayer(SqlDbContext dBContext)
        {
            _dbContext = dBContext;
        }

        public Task<List<UserChat>> GetUserChat(UserChatDto model)
        {
            return Task.Run(() =>
            {
                List<UserChat> userChat = null;
                try
                {
                    userChat = (from x in _dbContext.UserChat
                                where (x.Senderid == model.Senderid && x.Receiverid == model.Receiverid) || (x.Receiverid == model.Senderid && x.Senderid == model.Receiverid)
                                select x).ToList();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    userChat = null;
                }
                return userChat;
            });
        }

        public async Task<string> SaveUserChat(UserChat chatEntity)
        {
            string message = string.Empty;
            try
            {
                chatEntity.Chatid = _dbContext.UserChat.DefaultIfEmpty().Max(x => x == null ? 0 : x.Chatid) + 1;
                _dbContext.UserChat.Add(chatEntity);
                await _dbContext.SaveChangesAsync();
                message = "Saved";
            }
            catch (Exception ex)
            {
                message = "Error:" + ex.ToString();
            }
            return message;
        }
    }
}
