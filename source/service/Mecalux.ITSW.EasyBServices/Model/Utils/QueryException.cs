using System;
using System.Runtime.Serialization;

namespace Mecalux.ITSW.EasyBServices
{
    public class QueryException : Exception
    {
        public bool IsUnauthorizedAccessException { get; set; }
        public QueryException()
        {
            IsUnauthorizedAccessException = false;
        }

        public QueryException(String message)
            : base(message)
        {
            IsUnauthorizedAccessException = false;
        }

        public QueryException(String message, Exception innerException)
            : base(message, innerException)
        {
            IsUnauthorizedAccessException = innerException is UnauthorizedAccessException;
        }

        protected QueryException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            IsUnauthorizedAccessException = false;
        }
    }
}
