using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp.Deserializers;
using System.IO;
using ChatRoom.Models;


namespace ChatRoom
{
    public class Program
    {
        /// <summary>
        /// On Console Application mode, this standalone program gets called and does the deserialization for the JSON input string 
        /// The whole record could be viewed in the debug mode.
        /// </summary>
        public static void Main()
        {
            RestSharp.RestResponse restResponse = new RestSharp.RestResponse();
            restResponse.Content = File.ReadAllText("JSONData.txt"); ;

            RestSharp.Deserializers.JsonDeserializer jsonDeserializer = new JsonDeserializer();

            Record record = jsonDeserializer.Deserialize<Record>(restResponse);
            Console.WriteLine(record.has_title.ToString());
            Console.WriteLine(record.title.ToString());
        

            foreach (List<Object> item in record.entries)
            {
                Console.WriteLine(item[0].ToString());
                IDictionary<string, Object> recordContent;
                recordContent = item[1] as IDictionary<string,Object>;    
                foreach (var records in recordContent.Values)
                {
                    Console.WriteLine(records.ToString());
                }

            }

            Console.ReadLine();

        }

     
    }
}