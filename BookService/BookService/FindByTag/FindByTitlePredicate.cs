namespace BookService.FindByTag
{
    public class FindByTitlePredicate : IFindByTagPredicate
    {
        private string Title { get; set; }
        public FindByTitlePredicate(string title)
        {
            Title = title;
        }

        public bool IsOk(Book book)
        {
            return book.Title.CompareTo(Title) == 0;
        }
    }
}
