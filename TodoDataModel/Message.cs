using System;
using Akka.Routing;

namespace DataModel
{
    public class Message : IConsistentHashable
    {
        public Message(string data, Guid guid)
        {
            this.Data = data;
            Identifier = guid;
        }

        public Guid Identifier { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", Identifier, Data);
        }

        public string Data { get; private set; }

        public object ConsistentHashKey 
        {
            get { return Identifier; } 
        }
    }
}
