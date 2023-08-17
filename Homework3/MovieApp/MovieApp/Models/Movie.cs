using MovieApp.Models.Enums;

namespace MovieApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int year { get; set; }
        public Genre Genre { get; set; }
    }
}
