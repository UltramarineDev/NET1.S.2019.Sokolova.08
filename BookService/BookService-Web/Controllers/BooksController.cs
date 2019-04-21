using BookService;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BookService_Web.Controllers
{
    public class BooksController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddBook()
        {
            ViewBag.Response = "";
            return View();
        }

        public ActionResult ViewBooks()
        {

            var bookListServise = new BookListService(new BookListStorage());
            for(int i = 0; i < bookListServise.Books.Count; i++)
            {
                ViewBag.Book = $"{i}: {bookListServise.Books[i].ToString()}";
            }

            return View();
        }

        [HttpPost]
        public ActionResult Submit(string Author, string ISBN, string Title, uint PageCount, decimal Price,
            int PublicationYear, string PublishingOffice)
        {
            var book = new Book()
            {
                Author = Author,
                Title = Title,
                ISBN = ISBN,
                PublishingOffice = PublishingOffice,
                PublicationYear = PublicationYear,
                Price = Price,
                PageCount = PageCount
            };

            var bookListStorage = new BookListStorage();
            var bookListService = new BookListService(bookListStorage);

            bookListService.Add(new List<Book>() { book });

            bookListStorage.Save(bookListService.Books);

            ViewBag.Response = "Book added to Book List!";
            return View("AddBook");
        }
    }
}