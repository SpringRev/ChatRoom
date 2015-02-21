using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatRoom.Models
{
    /// <summary>
    /// Provides the matching keys to deserailize the incoming JSON Data
    /// </summary>
    public class Record
    {
        public bool has_title { get; set; }
        public string title { get; set; }
        public List<List<Object>> entries { get; set; }
    }
}