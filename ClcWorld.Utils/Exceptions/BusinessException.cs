using System;

namespace ClcWorld.Utils.Exceptions
{
    /// <summary>
    /// Represents errors that ocurrs during application execution related to the business logic.
    /// </summary>
    public class BusinessException : Exception
    {
        public BusinessException()
        {
        }

        public BusinessException(string message) : base(message)
        {
        }

        public BusinessException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
