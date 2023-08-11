using Homework2.Models;

namespace Homework2
{
    public static class StaticDb
    {
        public static List<Book> Books = new List<Book>()
        {
            new Book
            {
                Id = 1, 
                Author = "FirstAuthor",
                Title = "Book 1"
            },
            new Book
            {
                Id = 2,
                Author = "SecondAuthor",
                Title = "Book 2"
            },
            new Book
            {
                Id = 3,
                Author = "ThirdAuthor",
                Title = "Book 3"
            }
        };
    }
}
