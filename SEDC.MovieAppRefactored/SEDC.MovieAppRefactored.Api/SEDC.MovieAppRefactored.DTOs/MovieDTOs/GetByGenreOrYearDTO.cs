using SEDC.MovieAppRefactored.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.MovieAppRefactored.DTOs.MovieDTOs
{
    public class GetByGenreOrYearDTO
    {
        public int? Year { get; set; }
        public Genre? Genre { get; set; }
    }
}
