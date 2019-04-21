namespace BookService.FindByTag
{
    public interface IFindByTagPredicate
    {
        bool IsOk(Book book);
    }
}
