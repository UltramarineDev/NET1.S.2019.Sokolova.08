using System.Collections.Generic;

namespace BookService
{
    public static class FakeBookListStorage
    {
        public static List<Book> books = new List<Book>()
        {
            new Book()
            {
                Author = "Рихтер Джеффри",
                ISBN = "978-5-496-00-433-6",
                Title = "CLR via C#",
                PageCount = 896,
                Price = 300,
                PublicationYear = 2014,
                PublishingOffice = "Питер"
            }
        };
    }
}
