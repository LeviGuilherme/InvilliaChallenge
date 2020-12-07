using System;
using System.Runtime.Serialization;

namespace Invillia.Challenge.CrossCutting.Common
{
    public abstract class BaseException : Exception
    {
        public int StatusCode { get; private set; } = 500;

        public BaseException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }

        protected BaseException()
        {
        }

        protected BaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        protected BaseException(string message) : base(message)
        {
        }

        protected BaseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
