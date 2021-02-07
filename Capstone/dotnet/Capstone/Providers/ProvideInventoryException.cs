using System;
using System.Runtime.Serialization;

namespace Capstone.Providers
{
    [Serializable]
    public class ProvideInventoryException : Exception
    {
        public ProvideInventoryException() { }
        public ProvideInventoryException(string message) : base(message) { }
        public ProvideInventoryException(string message, Exception inner) : base(message, inner) { }
        protected ProvideInventoryException(
          SerializationInfo info,
          StreamingContext context) : base(info, context) { }
    }
}
