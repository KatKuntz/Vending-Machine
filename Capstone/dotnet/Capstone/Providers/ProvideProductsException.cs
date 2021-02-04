using System;
using System.Runtime.Serialization;

namespace Capstone.Providers
{
    class ProvideProductsException : Exception
    {
        public ProvideProductsException()
        {
        }

        public ProvideProductsException(string message) : base(message)
        {
        }

        public ProvideProductsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ProvideProductsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
