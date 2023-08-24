using MovieApp.DTOs;
using MovieApp.Mappers;
using MovieApp.Models;
using MovieApp.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [MaxLength(250, ErrorMessage = "Description cannot exceed 250 characters.")]
        public string? Description { get; set; }

        public int year { get; set; }

        public Genre Genre { get; set; }
    }
}
