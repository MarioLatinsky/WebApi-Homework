using SEDC.MovieAppRefactored.DataAccess;
using SEDC.MovieAppRefactored.Domain.Models;
using SEDC.MovieAppRefactored.Services.Abstraction;
using SEDC.MovieAppRefactored.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEDC.MovieAppRefactored.CustomExceptions;
using SEDC.MovieAppRefactored.DTOs.MovieDTOs;
using SEDC.MovieAppRefactored.DTOs.UserDTOs;

namespace SEDC.MovieAppRefactored.Services.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _movieRepository;
        public MovieService(IRepository<Movie> movieService)
        {
            _movieRepository = movieService;
        }
        public void CreateMovie(CreateMovieDTO AddMovie)
        {
            var newMovieDb = AddMovie.CreateDto();
            _movieRepository.CreateMovie(newMovieDb);
        }

        public void DeleteMovie(int id)
        {
            var movieFromDb = _movieRepository.GetById(id);
            if (movieFromDb != null)
            {
                throw new MovieDataException($"Movie with id {id} does not exist!");
            }

            _movieRepository.DeleteMovie(movieFromDb);
        }

        public List<MovieDTO> GetAll()
        {
            var movieFromDb = _movieRepository.GetAll();
            return movieFromDb.Select(movie => movie.MapToDto()).ToList();
        }

        public List<GetByGenreOrYearDTO> GetByGenreOrYear(int? year, int? genre)
        {

            var movieFromDb = _movieRepository.GetByGenreOrYear(year, genre).Select(movie => movie.ToDtogenreOrYear()).ToList();
            return movieFromDb;
            
        }

        public MovieDTO GetById(int id)
        {
            var movieFromDb = _movieRepository.GetById(id);
            if (movieFromDb is null)
            {
                throw new MovieDataException($"Movie with id {id} does not exist!");
            }
            return movieFromDb.MapToDto();
        }

        public LoginUserDTO LoginUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void RegisterUser(RegisterUserDTO entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateMovie(UpdateMovieDTO movie)
        {
            var movieFromDb = _movieRepository.GetById(movie.Id);
            if (movieFromDb is null)
            {
                throw new MovieDataException($"Movie with id {movie.Id} does not exist!");

            }
            movieFromDb.Title = movie.Title;
            movieFromDb.Year = movie.Year;
            movieFromDb.Genre = movie.Genre;
            movieFromDb.Description = movie.Description;
        }


    }
}
