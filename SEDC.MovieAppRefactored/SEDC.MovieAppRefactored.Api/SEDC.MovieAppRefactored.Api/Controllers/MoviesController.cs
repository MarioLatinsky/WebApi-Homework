using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using SEDC.MovieAppRefactored.CustomExceptions;
using SEDC.MovieAppRefactored.DataAccess.EntityImplementation;
using SEDC.MovieAppRefactored.Domain.Models;
using SEDC.MovieAppRefactored.Services.Abstraction;

namespace SEDC.MovieAppRefactored.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_movieService.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(500, "System error occured, contact admin!");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetByRouteId(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid id");
                }
                return Ok(_movieService.GetById(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured, please contact admin,");
            }
        }


        [HttpGet("queryId")]

        public IActionResult GetByQueryId([FromQuery] int id)
        {

            try
            {
                if (id == null)
                {
                    return BadRequest("Invalid input");
                }

                var movieFromDb = _movieService.GetById(id);

                if (movieFromDb == null)
                {
                    return BadRequest($"Movie with id {id} was not found.");
                }

                return Ok(movieFromDb);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured, please contact admin,");
            };
        }

        [HttpGet("getbygenreoryear")]
        public IActionResult GetByGenreOrYear([FromQuery] int? genre,
                                              [FromQuery] int? year)
        {
            try
            {
                if (genre is null && year is null)
                {
                    return BadRequest("At least one valid input is required.");
                }


                if (year <= 0)
                {
                    return BadRequest("Invalid year input.");

                }

                if(year != year)
                {
                    return BadRequest("Movie with this year doesnt exist");
                }


                if(genre <= 0)
                {
                    return BadRequest("Invalid genre input.");
                }

                if(genre != genre)
                {
                    return BadRequest("Movie of this genre doesnt exist");
                }

                return Ok(_movieService.GetByGenreOrYear(genre, year));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured, please contact admin,");

            }

        }

        //try
        //{
        //    if (genre <= 0 && year <= 0)
        //    {
        //        return BadRequest("At least one valid input is required.");
        //    }

        //    List<Movie> movies = new List<Movie>();

        //    if (year.HasValue)
        //    {
        //        movies.AddRange(_movieService.GetByYear(year));
        //    }

        //    if (genre.HasValue)
        //    {
        //        movies.AddRange(_movieService.GetByGenre(genre));
        //    }

        //    if (movies.Count == 0)
        //    {
        //        return NotFound("No movies found based on the provided criteria.");
        //    }

        //    return Ok(movies);
        //}
        //catch (Exception)
        //{
        //    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred. Please contact the administrator.");
        //}


    }
}
