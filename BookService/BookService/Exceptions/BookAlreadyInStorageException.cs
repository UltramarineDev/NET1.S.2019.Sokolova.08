using System;

namespace BookService.Exceptions
{
    public class BookAlreadyInStorageException : Exception
    {
        public override string Message
        {
            get
            {
                return "Book is already in storage.";
            }
        }
    }
}
