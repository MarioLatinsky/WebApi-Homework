using SEDC.MovieAppRefactored.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.MovieAppRefactored.DTOs.MovieDTOs
{
    public class CreateMovieDTO
    {
        public string Title { get; set; }

        [MaxLength(250, ErrorMessage = "Description cannot exceed 250 characters")]
        public string? Description { get; set; }
        public int Year { get; set; }
        public Genre Genre { get; set; }
    }
}
