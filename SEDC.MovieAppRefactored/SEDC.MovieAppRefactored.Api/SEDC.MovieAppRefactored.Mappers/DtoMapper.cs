using SEDC.MovieAppRefactored.Domain.Models;
using SEDC.MovieAppRefactored.DTOs.MovieDTOs;
using SEDC.MovieAppRefactored.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.MovieAppRefactored.Mappers
{
    public static class DtoMapper
    {
        public static MovieDTO MapToDto(this Movie movie)
        {
            return new MovieDTO()
            {
                Description = movie.Description,
                Genre = movie.Genre,
                Title = movie.Title,
                Year = movie.Year,
            };
        }


        public static GetByGenreOrYearDTO ToDtogenreOrYear(this Movie movie)
        {
            return new GetByGenreOrYearDTO()
            {
                Genre = movie.Genre,
                Year = movie.Year
            };
        }


        public static Movie CreateDto(this CreateMovieDTO movie)
        {
            return new Movie()
            {
                Description = movie.Description,
                Genre = movie.Genre,
                Title = movie.Title,
                Year = movie.Year,
            };
        }

        public static DeleteMovieDTO DeleteMovie(this Movie movie)
        {
            return new DeleteMovieDTO()
            {
                Id = movie.Id,
            };
        }

        public static LoginUserDTO MapToLoginUserDto(this User user)
        {
            return new LoginUserDTO()
            {
                Username = user.Username,
                Password = user.Password,
            };
        }

        public static RegisterUserDTO MapToRegisterUserDto(this User user)
        {
            return new RegisterUserDTO()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Password = user.Password,
            };
        }

    }
}
