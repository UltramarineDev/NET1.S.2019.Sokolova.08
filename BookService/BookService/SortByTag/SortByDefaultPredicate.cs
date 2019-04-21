namespace BookService.SortByTag
{
    public class SortByDefaultPredicate : ISortByTagPredicate
    {
        public bool Compare(Book bookFirst, Book bookSecond)
        {
            return bookFirst.CompareTo(bookSecond) != 1;
        }
    }
}
