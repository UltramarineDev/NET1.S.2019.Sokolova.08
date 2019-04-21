using System.Collections.Generic;

namespace BookService
{
    public interface IBookListStorage
    {
        IEnumerable<Book> Load();
        void Save(IEnumerable<Book> books);
    }

    public class BookListStorage : IBookListStorage
    {
        public IEnumerable<Book> Load()
        {
            return FakeBookListStorage.books;
        }

        public void Save(IEnumerable<Book> books)
        {
            FakeBookListStorage.books = new List<Book>(books);
        }
    }
}
