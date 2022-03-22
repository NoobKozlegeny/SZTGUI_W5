using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Endpoint.Models
{
    public class Message
    {
        public string Msg { get; set; }

        public DateTime DTStamp { get; set; }
        public string SenderName { get; set; }
    }
}
