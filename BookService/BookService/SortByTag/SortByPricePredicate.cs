namespace BookService.SortByTag
{
    public class SortByPricePredicate : ISortByTagPredicate
    {
        public bool Compare(Book bookFirst, Book bookSecond)
        {
            return bookFirst.Price <= bookSecond.Price;
        }
    }
}
