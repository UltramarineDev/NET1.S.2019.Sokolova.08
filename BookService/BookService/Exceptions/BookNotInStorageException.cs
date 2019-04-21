using System;

namespace BookService.Exceptions
{
    public class BookNotInStorageException : Exception
    {
        public override string Message
        {
            get
            {
                return "Can not find book in current storage.";
            }
        }
    }
}
