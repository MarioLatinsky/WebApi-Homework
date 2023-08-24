using MovieApp.DTOs;
using MovieApp.Models;
using System.Reflection.Metadata.Ecma335;

namespace MovieApp.Mappers
{
    public static class DtoMapper
    {
        public static MovieDto MapToDto(this Movie movie)
        {
            return new MovieDto()
            {
                Id = movie.Id,
                Description = movie.Description,
                Genre = movie.Genre,
                Title = movie.Title,
                year = movie.year
                
            };
        }

      
    }
}
