using System;

namespace Application.Common.CustomExceptions
{
    public class NotFoundEntityException : Exception
    {
        public NotFoundEntityException(string name, object key) : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }
    }
}