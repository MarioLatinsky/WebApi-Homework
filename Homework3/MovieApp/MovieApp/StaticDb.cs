using MovieApp.Models;
using MovieApp.Models.Enums;
namespace MovieApp
{
    public static class StaticDb
    {
        public static List<Movie> Movies = new List<Movie>()
        {
            new Movie
            {
                Id = 1,
                Title = "Movie1",
                Description = "Description 1",
                year = 2009,
                Genre = Genre.Action
            },
            new Movie
            {
                Id = 2,
                Title = "Movie2",
                Description = "Description 2",
                year = 1991,
                Genre = Genre.Thriller
            },
            new Movie
            {
                Id = 3,
                Title = "Movie3",
                Description = "Description 3",
                year = 2020,
                Genre = Genre.Comedy
            },

        };
    }
}
