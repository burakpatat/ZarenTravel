using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikOdeme.Core.Exceptions
{
    public class BirlesikOdemeException : Exception
    {
        public BirlesikOdemeException()
        {

        }
        public BirlesikOdemeException(string message) : base(message)
        {
        }

        public BirlesikOdemeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public BirlesikOdemeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
