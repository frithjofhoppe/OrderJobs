using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace OrderedJobs
{
    public class OrderJobSortException : Exception
    {
        public OrderJobSortException()
        {
        }

        public OrderJobSortException(string message) : base(message)
        {
        }

        public OrderJobSortException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OrderJobSortException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
