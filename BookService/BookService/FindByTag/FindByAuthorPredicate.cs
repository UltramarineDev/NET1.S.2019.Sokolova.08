namespace BookService.FindByTag
{
    public class FindByAuthorPredicate : IFindByTagPredicate
    {
        private string Author { get; set; }
        public FindByAuthorPredicate(string author)
        {
            Author = author;
        }

        public bool IsOk(Book book)
        {
            return book.Author.CompareTo(Author) == 0;
        }
    }
}
