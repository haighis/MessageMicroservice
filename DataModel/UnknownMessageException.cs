using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class UnknownMessageException : MessageException
    {
        public UnknownMessageException(string message)
            : base(message)
        {
        }

        public UnknownMessageException(string message, Exception innerEx)
            : base(message, innerEx)
        {
        }
    }
}
