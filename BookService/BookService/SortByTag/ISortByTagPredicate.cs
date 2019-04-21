namespace BookService.SortByTag
{
    public interface ISortByTagPredicate
    {
        bool Compare(Book bookFirst, Book bookSecond);
    }
}
