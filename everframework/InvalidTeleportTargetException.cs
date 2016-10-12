using System;
using System.Runtime.Serialization;

namespace everframework
{
    [Serializable]
    internal class InvalidTeleportTargetException : Exception
    {
        public InvalidTeleportTargetException(string message) : base(message)
        {
        }
    }
}