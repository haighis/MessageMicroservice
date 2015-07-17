using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    /// <summary>
    /// Base class for all exceptions
    /// </summary>
    public abstract class MessageException : Exception
    {
        protected MessageException(string message) : base(message) { }

        protected MessageException(string message, Exception innerEx) : base(message, innerEx) { }
    }
}
