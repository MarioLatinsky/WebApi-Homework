using SEDC.MovieAppRefactored.Domain.Models;
using SEDC.MovieAppRefactored.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.MovieAppRefactored.DataAccess.EntityImplementation
{
    public class MovieRepository : IRepository<Movie>
    {
        private readonly MovieAppDbContext _dbContext;

        public MovieRepository(MovieAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateMovie(Movie entity)
        {
            _dbContext.Movies.Add(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteMovie(Movie entity)
        {
            _dbContext.Movies.Remove(entity);  
            _dbContext.SaveChanges();
        }

        public List<Movie> GetAll()
        {
            return _dbContext.Movies.ToList();
        }

        public List<Movie> GetByGenreOrYear(int? genre, int? year)
        {
         
            var movie = new List<Movie>();
            if(genre is not null)
            {
               
                return _dbContext.Movies.Where(movie => (int)movie.Genre == genre).ToList(); 
                
            }

            if(year is not null)
            {

                return _dbContext.Movies.Where(movie => movie.Year == year).ToList();
            }


            return movie;
        }



        //public List<Movie> GetByGenre(int? genre)
        //{
        //    return _dbContext.Movies
        //        .Where(movie => genre.HasValue && (int)movie.Genre == genre)
        //        .ToList();
        //}
        //public List<Movie> GetByYear(int? year)
        //{
        //    return _dbContext.Movies
        //        .Where(movie => year.HasValue && movie.Year == year)
        //        .ToList();
        //}


        public Movie GetById(int id)
        {
            return _dbContext.Movies.SingleOrDefault(movie => movie.Id == id);
        }

        public void UpdateMovie(Movie entity)
        {
            _dbContext.Movies.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
