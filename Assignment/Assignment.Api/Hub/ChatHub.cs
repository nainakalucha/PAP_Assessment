using Assignment.BLL;
using Assignment.Contract;
using Assignment.Model;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Api
{
    public class ChatHub : Hub
    {
        private readonly static ConnectionMapping<string> _connections = new ConnectionMapping<string>();
        private IChatManager _chatManager;

        public ChatHub(IChatManager chatManager)
        {
            _chatManager = chatManager;
        }

        public async Task SendMessage(UserChatDto message)
        {
            //var httpContext = Context.GetHttpContext();
            //var services = httpContext.RequestServices;
            //var chatDalLayerInstance = (IChatDalLayer)services.GetService(typeof(IChatDalLayer));

            //_chatManager = new ChatManager(chatDalLayerInstance);
            //Receive Message
            List<string> ReceiverConnectionids = _connections.GetConnections(message.Receiverid).ToList<string>();
            if (ReceiverConnectionids.Count() > 0)
            {
                //Save-Receive-Message
                try
                {
                    message.Connectionid = string.Join(",", ReceiverConnectionids);
                    var userChatEntity = new UserChat();
                    userChatEntity.Connectionid = message.Connectionid;
                    userChatEntity.Message = message.Message;
                    userChatEntity.Messagedate = message.Messagedate;
                    userChatEntity.Messagestatus = message.Messagestatus;
                    userChatEntity.Receiverid = message.Receiverid;
                    userChatEntity.Senderid = message.Senderid;
                    userChatEntity.IsPrivate = true;
                    await _chatManager.SaveUserChat(userChatEntity);
                    await Clients.Clients(ReceiverConnectionids).SendAsync("ReceiveMessage", message);
                }
                catch (Exception) { }
            }
        }

        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            if (httpContext != null)
            {
                try
                {
                    //Add Logged User
                    var userName = httpContext.Request.Query["user"].ToString();
                    _connections.Add(userName, Context.ConnectionId.ToString());

                    //Update Client
                    await Clients.All.SendAsync("UpdateUserList", _connections.ToJson());
                }
                catch (Exception) { }
            }
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var httpContext = Context.GetHttpContext();
            if (httpContext != null)
            {
                //Remove Logged User
                var username = httpContext.Request.Query["user"];
                _connections.Remove(username, Context.ConnectionId);

                //Update Client
                await Clients.All.SendAsync("UpdateUserList", _connections.ToJson());
            }
        }
    }
}
