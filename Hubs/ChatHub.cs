using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using ChatRoom.Models;

namespace ChatRoom
{
    /// <summary>
    /// Provides hub Class for duplex single socket communication operations 
    /// </summary>
    public class ChatHub : Hub
    {
        public static Queue<ChatModel> chatMessageQueue = new Queue<ChatModel>();
        public static Dictionary<string, string> UserList = new Dictionary<string, string>();

        /// <summary>
        /// Called when the user logs in to system. 
        /// The hub instance makes callback to the clients to show the available user limits if the user limit is exceeded
        /// and if the user is connected it makes callbacks to the client to display the currently logged in user list and the last 15 messages 
        /// </summary>
        /// <param name="user"></param>
        public void Login(string user)
        {
            UserList.Add(this.Context.ConnectionId, user);
            if (UserList.Count > 20)
                Clients.Caller.callchat();
            Clients.All.displayUserList(UserList.Values);
            Clients.All.displayMessages(chatMessageQueue);

        }

        /// <summary>
        /// Called when user tries to disconnect or close the system.
        /// The ConnectionId is removed from the Hub and the hub makes client callback to update the current user list
        /// and the connection for this user instance gets closed
        /// </summary>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            string connectionId = this.Context.ConnectionId;
            UserList.Remove(connectionId);
            Clients.All.displayUserList(UserList.Values);
            return base.OnDisconnected(stopCalled);

        }

        /// <summary>
        /// Called when the server send method is called through hub connection from clients.
        /// It takes in the user instance and the corresponding messages to update the message queue
        /// and it makes a client callback to update the message list
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="chatMessage"></param>
        public void Send(string userName, string chatMessage)
        {
            ChatModel chatModel = new ChatModel();

            chatModel.UserName = userName;
            chatModel.ChatMessage = chatMessage;

            if (chatMessageQueue.Count > 14)
            {
                chatMessageQueue.Dequeue();
            }

            chatMessageQueue.Enqueue(chatModel);

            Clients.All.displayMessages(chatMessageQueue);

        }
    }

}