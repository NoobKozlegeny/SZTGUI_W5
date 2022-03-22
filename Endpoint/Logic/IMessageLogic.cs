using Endpoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Endpoint.Logic
{
    public interface IMessageLogic
    {
        public void Create(Message msg);
        public Message Get(DateTime timestamp, string sender);
        public ICollection<Message> GetAll();

    }
}
