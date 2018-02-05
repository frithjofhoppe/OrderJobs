using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace OrderedJobs
{
    public class CircularReferenceException : Exception
    {
        public CircularReferenceException()
        {
        }

        public CircularReferenceException(string message) : base(message)
        {
        }

        public CircularReferenceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CircularReferenceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
