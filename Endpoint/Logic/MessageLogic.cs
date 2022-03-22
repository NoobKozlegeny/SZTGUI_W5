using Endpoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Endpoint.Logic
{
    public class MessageLogic : IMessageLogic
    {
        ICollection<Message> chatDb;

        public void Create(Message msg)
        {
            chatDb.Add(msg) ;
        }

        public Message Get(DateTime timestamp, string sender)
        {
            return chatDb.FirstOrDefault((x) => x.DTStamp == timestamp && x.SenderName == sender);
        }

        public ICollection<Message> GetAll()
        {
            return chatDb;
        }
    }
}
