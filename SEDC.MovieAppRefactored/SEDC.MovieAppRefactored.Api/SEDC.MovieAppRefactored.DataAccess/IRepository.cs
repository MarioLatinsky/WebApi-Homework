using SEDC.MovieAppRefactored.Domain.Enums;
using SEDC.MovieAppRefactored.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.MovieAppRefactored.DataAccess
{
    public interface IRepository<T>
    {

        List<T> GetAll();
        T GetById(int id);
        List<T> GetByGenreOrYear(int? year, int? genre);
        //List<Movie> GetByGenre(int? genre);
        //List<Movie> GetByYear(int? year);
        void CreateMovie(T entity);
        void UpdateMovie(T entity);
        void DeleteMovie(T entity);
    }
}
