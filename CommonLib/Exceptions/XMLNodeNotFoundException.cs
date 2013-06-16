using System;

namespace CommonLib.Exceptions
{
     [Serializable]
    public class XMLNodeNotFoundException : Exception
    {
        public XMLNodeNotFoundException() : base("[default exception message] XML node not found.") { }
        public XMLNodeNotFoundException(string message) : base(message) { }
        public XMLNodeNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
