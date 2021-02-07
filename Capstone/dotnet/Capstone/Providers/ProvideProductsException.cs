using System;
using System.Runtime.Serialization;

namespace Capstone.Providers
{
    [Serializable]
    public class ProvideProductsException : Exception
    {
        public ProvideProductsException() { }
        public ProvideProductsException(string message) : base(message) { }
        public ProvideProductsException(string message, Exception inner) : base(message, inner) { }
        protected ProvideProductsException(
          SerializationInfo info,
          StreamingContext context) : base(info, context) { }
    }
}
