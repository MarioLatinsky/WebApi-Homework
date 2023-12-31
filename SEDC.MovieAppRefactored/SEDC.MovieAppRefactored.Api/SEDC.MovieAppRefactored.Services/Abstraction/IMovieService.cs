﻿using SEDC.MovieAppRefactored.DataAccess;
using SEDC.MovieAppRefactored.Domain.Models;
using SEDC.MovieAppRefactored.DTOs.MovieDTOs;
using SEDC.MovieAppRefactored.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.MovieAppRefactored.Services.Abstraction
{
    public interface IMovieService 
    {
        List<MovieDTO> GetAll();
        MovieDTO GetById(int id);
        List<GetByGenreOrYearDTO> GetByGenreOrYear(int? year, int? genre);
        LoginUserDTO LoginUser(string username, string password);
        void RegisterUser(RegisterUserDTO entity);
        void CreateMovie(CreateMovieDTO movie);
        void UpdateMovie(UpdateMovieDTO movie);
        void DeleteMovie(int id);
    }
}
