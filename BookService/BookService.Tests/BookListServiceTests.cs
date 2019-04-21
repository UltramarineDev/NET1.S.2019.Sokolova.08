using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BookService.Tests
{
    public class BookListServiceTests
    {
        [Test]
        public void AddTest()
        {
            FakeBookListStorage.books = new List<Book>()
            {
                new Book()
            {
                Author = "Рихтер Джеффри",
                ISBN = "978-5-496-00-433-6",
                Title = "CLR via C#",
                PageCount = 896,
                Price = 70,
                PublicationYear = 2014,
                PublishingOffice = "Питер"
                }
            };

            var bookFirstToAdd = new Book()
            {
                Author = "Тепляков Сергей",
                ISBN = "978-5-496-01649-0",
                Title = "Паттерны проектирования",
                PageCount = 320,
                Price = 100,
                PublicationYear = 2016,
                PublishingOffice = "Питер"
            };

            var bookSecondToAdd = new Book()
            {
                Author = "Албахари",
                ISBN = "978-5-496-00-433-6",
                Title = "C# 3.0 справочник",
                PageCount = 944,
                Price = 23,
                PublicationYear = 2012,
                PublishingOffice = "BHV"
            };

            var bookList = new List<Book>();
            bookList.Add(bookFirstToAdd);
            bookList.Add(bookSecondToAdd);

            var bookListService = new BookListService(new BookListStorage());

            bookListService.Add(bookList);

            Assert.AreEqual(3, bookListService.Books.Count);
            Assert.AreEqual(bookFirstToAdd, bookListService.Books[1]);
            Assert.AreEqual(bookSecondToAdd, bookListService.Books[2]);
        }

        [Test]
        public void FindByAuthorTests()
        {
            FakeBookListStorage.books = new List<Book>()
            {
                new Book()
                {
                Author = "Рихтер Джеффри",
                ISBN = "978-5-496-00-433-6",
                Title = "CLR via C#",
                PageCount = 896,
                Price = 70,
                PublicationYear = 2014,
                PublishingOffice = "Питер"
                },

                new Book()
                {
                Author = "Тепляков Сергей",
                ISBN = "978-5-496-01649-0",
                Title = "Паттерны проектирования",
                PageCount = 320,
                Price = 100,
                PublicationYear = 2016,
                PublishingOffice = "Питер"
                },

                new Book()
                {
                Author = "Албахари",
                ISBN = "978-5-496-00-433-6",
                Title = "C# 3.0 справочник",
                PageCount = 944,
                Price = 23,
                PublicationYear = 2012,
                PublishingOffice = "BHV"
                }
            };

            var bookListService = new BookListService(new BookListStorage());

            var actualbookList = bookListService.FindByTag(new FindByTag.FindByAuthorPredicate("Тепляков Сергей"));

            var expectedBookList = new List<Book>()
            {
                new Book()
                {
                Author = "Тепляков Сергей",
                ISBN = "978-5-496-01649-0",
                Title = "Паттерны проектирования",
                PageCount = 320,
                Price = 100,
                PublicationYear = 2016,
                PublishingOffice = "Питер"
                }
            };

            Assert.AreEqual(expectedBookList, actualbookList);
        }

        [Test]
        public void FindByTitleTests()
        {
            FakeBookListStorage.books = new List<Book>()
            {
                new Book()
                {
                Author = "Рихтер Джеффри",
                ISBN = "978-5-496-00-433-6",
                Title = "CLR via C#",
                PageCount = 896,
                Price = 70,
                PublicationYear = 2014,
                PublishingOffice = "Питер"
                },

                new Book()
                {
                Author = "Тепляков Сергей",
                ISBN = "978-5-496-01649-0",
                Title = "Паттерны проектирования",
                PageCount = 320,
                Price = 100,
                PublicationYear = 2016,
                PublishingOffice = "Питер"
                },

                new Book()
                {
                Author = "Албахари",
                ISBN = "978-5-496-00-433-6",
                Title = "C# 3.0 справочник",
                PageCount = 944,
                Price = 23,
                PublicationYear = 2012,
                PublishingOffice = "BHV"
                }
            };
            var bookListService = new BookListService(new BookListStorage());

            var actualbookList = bookListService.FindByTag(new FindByTag.FindByTitlePredicate("C# 3.0 справочник"));

            var expectedBookList = new List<Book>()
            {
                new Book()
                {
                Author = "Албахари",
                ISBN = "978-5-496-00-433-6",
                Title = "C# 3.0 справочник",
                PageCount = 944,
                Price = 23,
                PublicationYear = 2012,
                PublishingOffice = "BHV"
                }
            };

            Assert.AreEqual(expectedBookList, actualbookList);
        }

        [Test]
        public void SortByDefaultPredicateTests()
        {
            FakeBookListStorage.books = new List<Book>()
            {
                new Book()
                {
                Author = "Рихтер Джеффри",
                ISBN = "978-5-496-00-433-6",
                Title = "CLR via C#",
                PageCount = 896,
                Price = 70,
                PublicationYear = 2014,
                PublishingOffice = "Питер"
                },

                new Book()
                {
                Author = "Тепляков Сергей",
                ISBN = "978-5-496-01649-0",
                Title = "Паттерны проектирования",
                PageCount = 320,
                Price = 100,
                PublicationYear = 2016,
                PublishingOffice = "Питер"
                },

                new Book()
                {
                Author = "Албахари",
                ISBN = "978-5-496-00-433-6",
                Title = "C# 3.0 справочник",
                PageCount = 944,
                Price = 23,
                PublicationYear = 2012,
                PublishingOffice = "BHV"
                }
            };

            var bookListService = new BookListService(new BookListStorage());

            bookListService.SortBy();

            Assert.AreEqual(FakeBookListStorage.books[0], bookListService.Books[1]);
            Assert.AreEqual(FakeBookListStorage.books[1], bookListService.Books[2]);
            Assert.AreEqual(FakeBookListStorage.books[2], bookListService.Books[0]);
        }

        [Test]
        public void SortByPricePredicateTests()
        {
            FakeBookListStorage.books = new List<Book>()
            {
                new Book()
                {
                Author = "Рихтер Джеффри",
                ISBN = "978-5-496-00-433-6",
                Title = "CLR via C#",
                PageCount = 896,
                Price = 70,
                PublicationYear = 2014,
                PublishingOffice = "Питер"
                },

                new Book()
                {
                Author = "Тепляков Сергей",
                ISBN = "978-5-496-01649-0",
                Title = "Паттерны проектирования",
                PageCount = 320,
                Price = 100,
                PublicationYear = 2016,
                PublishingOffice = "Питер"
                },

                new Book()
                {
                Author = "Албахари",
                ISBN = "978-5-496-00-433-6",
                Title = "C# 3.0 справочник",
                PageCount = 944,
                Price = 23,
                PublicationYear = 2012,
                PublishingOffice = "BHV"
                }
            };

            var bookListService = new BookListService(new BookListStorage());

            bookListService.SortBy(new SortByTag.SortByPricePredicate());

            Assert.AreEqual(FakeBookListStorage.books[0], bookListService.Books[1]);
            Assert.AreEqual(FakeBookListStorage.books[1], bookListService.Books[2]);
            Assert.AreEqual(FakeBookListStorage.books[2], bookListService.Books[0]);
        }

        [Test]
        public void BookAlreadyInStorageExceptionTest()
        {
            FakeBookListStorage.books = new List<Book>()
            {
                new Book()
            {
                Author = "Рихтер Джеффри",
                ISBN = "978-5-496-00-433-6",
                Title = "CLR via C#",
                PageCount = 896,
                Price = 70,
                PublicationYear = 2014,
                PublishingOffice = "Питер"
                }
            };

            var bookToAdd = new List<Book>()
            {
                new Book()
                {
                Author = "Рихтер Джеффри",
                ISBN = "978-5-496-00-433-6",
                Title = "CLR via C#",
                PageCount = 896,
                Price = 70,
                PublicationYear = 2014,
                PublishingOffice = "Питер"
                }
            };

            var bookListService = new BookListService(new BookListStorage());

            Assert.Throws<Exceptions.BookAlreadyInStorageException>(() =>  bookListService.Add(bookToAdd));
        }

        [Test]
        public void BookNotInStorageExceptionTest()
        {
            FakeBookListStorage.books = new List<Book>()
            {
                new Book()
            {
                Author = "Рихтер Джеффри",
                ISBN = "978-5-496-00-433-6",
                Title = "CLR via C#",
                PageCount = 896,
                Price = 70,
                PublicationYear = 2014,
                PublishingOffice = "Питер"
                }
            };

            var bookListService = new BookListService(new BookListStorage());

            Assert.Throws<Exceptions.BookNotInStorageException>(() => 
            bookListService.FindByTag(new FindByTag.FindByAuthorPredicate("Тепляков Сергей")));
        }
    }
}