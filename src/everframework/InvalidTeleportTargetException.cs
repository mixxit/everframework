using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace everframework
{
    public class InvalidTeleportTargetException : Exception
    {
        public InvalidTeleportTargetException(string message) : base(message)
        {
        }
    }
}
