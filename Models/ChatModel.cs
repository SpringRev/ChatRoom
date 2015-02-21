using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatRoom.Models
{
    /// <summary>
    /// Provides properties to store the User and the corresponding chat message
    /// </summary>
    public class ChatModel
    {
        public string UserName { get; set; }
        public string ChatMessage { get; set; }
    }
}