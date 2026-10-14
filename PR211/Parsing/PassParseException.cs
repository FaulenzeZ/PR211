using System;

namespace PR211.Parsing
{
    public class PassParseException : Exception
    {
        public PassParseException(string message)
            : base(message) { }

        public PassParseException(string message, Exception inner)
            : base(message, inner) { }
    }
}