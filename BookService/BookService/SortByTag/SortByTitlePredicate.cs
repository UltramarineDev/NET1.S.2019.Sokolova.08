using System;

namespace BookService.SortByTag
{
    class SortByTitlePredicate : ISortByTagPredicate
    {
        public bool Compare(Book bookFirst, Book bookSecond)
        {
            return bookFirst.Title.CompareTo(bookSecond.Title) != -1;
        }
    }
}
