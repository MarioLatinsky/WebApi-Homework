using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.MovieAppRefactored.DataAccess;
using SEDC.MovieAppRefactored.DataAccess.EntityImplementation;
using SEDC.MovieAppRefactored.Domain.Models;
using SEDC.MovieAppRefactored.Services.Abstraction;
using SEDC.MovieAppRefactored.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.MovieAppRefactored.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MovieAppDbContext>(options =>
                     options.UseSqlServer(connectionString)); 
        } 

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Movie>, MovieRepository>();
        }

        public static void RegisterService(this IServiceCollection services)
        {
            services.AddTransient<IMovieService, MovieService>();
        }
    }
}
