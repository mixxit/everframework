using System;
using System.Runtime.Serialization;

namespace everframework
{
    [Serializable]
    public class InvalidTeleportTargetException : Exception
    {
        public InvalidTeleportTargetException(string message) : base(message)
        {
        }
    }
}