using System;

namespace Application.Common.CustomExceptions
{
    public class AlreadyDeletedEntityException : Exception
    {
        public AlreadyDeletedEntityException(string name, object key) 
            : base($"Entity \"{name}\" ({key}) has already been deleted.")
        {
        }
    }
}