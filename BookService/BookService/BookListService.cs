using BookService.Exceptions;
using BookService.FindByTag;
using BookService.SortByTag;
using System.Collections.Generic;

namespace BookService
{
    public interface IBookListService
    {
        void Add(IEnumerable<Book> books);
        void Remove(Book book);
        IEnumerable<Book> FindByTag(IFindByTagPredicate predicate);
    }

    public class BookListService : IBookListService
    {
        private List<Book> books;

        public List<Book> Books
        {
            get
            {
                return books;
            }
        }

        public BookListService(IBookListStorage bookListStorage)
        {
            books = new List<Book>(bookListStorage.Load());
        }

        public void Add(IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                if (this.books.Contains(book))
                {
                    throw new BookAlreadyInStorageException();
                }
            }

            this.books.AddRange(books);
        }

        public IEnumerable<Book> FindByTag(IFindByTagPredicate predicate)
        {
            List<Book> resultBooksList = new List<Book>();

            foreach (var book in this.books)
            {
                if (predicate.IsOk(book))
                {
                    resultBooksList.Add(book);
                }
            }

            if(resultBooksList.Count == 0)
            {
                throw new Exceptions.BookNotInStorageException();
            }

            return resultBooksList;
        }

        public void Remove(Book bookToRemove)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Equals(bookToRemove))
                {
                    books.Remove(bookToRemove);
                    return;
                }
            }

            throw new BookNotInStorageException();
        }

        public void SortBy(ISortByTagPredicate sortByTagPredicate = null)
        {
            if (sortByTagPredicate == null)
            {
                sortByTagPredicate = new SortByDefaultPredicate();
            }

            for (int i = 0; i < books.Count; i++)
            {
                for (int j = 0; j < books.Count - 1; j++)
                {
                    if (!sortByTagPredicate.Compare(books[j], books[j + 1]))
                    {
                        var temp = books[j];
                        books[j] = books[j + 1];
                        books[j + 1] = temp;
                    }
                }
            }
        }
    }
}
