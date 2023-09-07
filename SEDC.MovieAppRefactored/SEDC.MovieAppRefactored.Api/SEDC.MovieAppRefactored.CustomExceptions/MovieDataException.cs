using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.MovieAppRefactored.CustomExceptions
{
    public class MovieDataException : Exception
    {
        public MovieDataException() : base("Generic Movie Data exception occured") { }

        public MovieDataException(string message) : base(message) { }
    }
}
