using Microsoft.EntityFrameworkCore;
using SEDC.MovieAppRefactored.Domain.Models;
using SEDC.MovieAppRefactored.Domain.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.MovieAppRefactored.DataAccess
{
    public class MovieAppDbContext : DbContext
    {
        public MovieAppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // validations
            modelBuilder.Entity<Movie>()
                .Property(x => x.Title)
                .IsRequired();

            modelBuilder.Entity<Movie>()
                .Property(x => x.Year)
                .IsRequired();

            modelBuilder.Entity<Movie>()
                .Property(x => x.Genre)
                .IsRequired();

            // Seed 

            modelBuilder.Entity<Movie>()
                .HasData(new Movie
                {
                    Id = 1,
                    Description = "This is the first movie",
                    Genre = Genre.Action,
                    Title = "Movie 1",
                    Year = 2023
                });


            modelBuilder.Entity<Movie>()
                .HasData(new Movie
                {
                    Id = 2,
                    Description = "This is the second movie",
                    Genre = Genre.Comedy,
                    Title = "Movie 2",
                    Year = 2024
                });


            modelBuilder.Entity<Movie>()
                .HasData(new Movie
                {
                    Id = 3,
                    Description = "This is the third movie",
                    Genre = Genre.Thriller,
                    Title = "Movie 3",
                    Year = 2025
                });

            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = 1,
                    FirstName = "Mario",
                    LastName = "Latinski",
                    FavoriteGenre = Genre.Action,
                    Password = "",
                    Username = "m.latinski",
                    MoviesList = new List<Movie>()
                });

            modelBuilder.Entity<User>()
           .HasData(new User
           {
               Id = 2,
               FirstName = "John",
               LastName = "Johnson",
               FavoriteGenre = Genre.Comedy,
               Password = "",
               Username = "j.johnson",
               MoviesList = new List<Movie>()
           });



        }
    }
}
