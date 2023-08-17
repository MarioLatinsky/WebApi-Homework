using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.DTOs;
using MovieApp.Mappers;
using MovieApp.Models;
using MovieApp.Models.Enums;
using System.Reflection.Metadata.Ecma335;

namespace MovieApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAll()  //https://localhost:7221/api/movies
        {
            try
            {
                var moviesDb = StaticDb.Movies.Select(movie => movie.MapToDto()).ToList();
                return Ok(moviesDb);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred, please contact admin.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdRoute([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid id");
                }

                var movieFromDb = StaticDb.Movies.Select(movie => movie.MapToDto()).FirstOrDefault(movie => movie.Id == id);

                if (movieFromDb is null)
                {
                    return NotFound($"Movie with id: {id} was not found");
                }

                return Ok(movieFromDb);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred, please contact admin.");
            };
        }


        [HttpGet("findbyid")]
        public IActionResult GetByIdQuery([FromQuery] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Invalid id");
                }

                var movieFromDb = StaticDb.Movies.Select(movie => movie.MapToDto()).FirstOrDefault(movie => movie.Id == id);

                if (movieFromDb is null)
                {
                    return NotFound($"Movie with id: {id} was not found");
                }

                return Ok(movieFromDb);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred, please contact admin.");
            };
        }

        [HttpGet("getbygenreoryear")]
        public IActionResult GetByGenreOrYear([FromQuery] int? genre,
                                              [FromQuery] int? year)
        {
            try
            {
                if (genre <= 0 && year <= 0)
                {
                    return BadRequest("At least one valid input is required.");
                }

                var movieFromDb = StaticDb.Movies.Select(movie => movie.MapToDto()).ToList();

                if (year is not null)
                {
                    if (year <= 0)
                    {
                        return BadRequest("Invalid Year input.");
                    }
                    movieFromDb = movieFromDb.Where(movie => movie.year == year).ToList();
                }

                if (genre is not null)
                {
                    if (genre <= 0)
                    {
                        return BadRequest("Invalid Genre input.");
                    }
                    movieFromDb = movieFromDb.Where(movie => (int)movie.Genre == genre).ToList();
                }

                return Ok(movieFromDb);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred, please contact admin.");
            }
        }

        [HttpPost]
        public IActionResult CreateMovie([FromBody] MovieDto movieDto)
        {
            try
            {

                var movieDb = StaticDb.Movies.FirstOrDefault(user => user.Id == movieDto.Id);

                movieDb = new Movie
                {
                    Id = movieDto.Id,
                    Description = movieDto.Description,
                    Genre = movieDto.Genre,
                    Title = movieDto.Title,
                    year = movieDto.year
                };

                if (!Enum.IsDefined(typeof(Genre), movieDto.Genre))
                {
                    return BadRequest("Invalid Genre value.");
                }


                StaticDb.Movies.Add(movieDb);

                return StatusCode(StatusCodes.Status201Created, "Movie created !");


            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred, please contact admin.");
            }
        }


        [HttpPut()]
        public IActionResult UpdateMovie([FromBody] MovieDto movieDto)
        {
            try
            {
                var movieDb = StaticDb.Movies.FirstOrDefault(user => user.Id == movieDto.Id);
                if (movieDb is null)
                {
                    return NotFound("Movie not found");
                }


                movieDb.Id = movieDto.Id;
                movieDb.Description = movieDto.Description;
                movieDb.Genre = movieDto.Genre;
                movieDb.Title = movieDto.Title;
                movieDb.year = movieDto.year;
                

                if (!Enum.IsDefined(typeof(Genre), movieDto.Genre))
                {
                    return BadRequest("Invalid Genre value.");
                }

                StaticDb.Movies.Add(movieDb);

                return StatusCode(StatusCodes.Status202Accepted, "Movie Updated");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred, please contact admin.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMove([FromRoute] int id)
        {
            try
            {
                if(id <= 0)
                {
                    return BadRequest("The id can not be negative!");

                }
                var movieDb = StaticDb.Movies.FirstOrDefault(user => user.Id == id);
                if (movieDb is null)
                {
                    return NotFound("Movie not found");
                }

                StaticDb.Movies.Remove(movieDb);
                return Ok("Movie was deleted successfully");

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred, please contact admin.");

            }
        }

        [HttpDelete("deletefrombody")]
        public IActionResult DeleteFromBody([FromBody] DeleteMovieDto movieDto)
        {
            try
            {
                var movieDb = StaticDb.Movies.FirstOrDefault(user => user.Id == movieDto.Id);
                if (movieDb is null)
                {
                    return NotFound("Movie not found");
                }

                movieDb.Id = movieDto.Id;
                
                StaticDb.Movies.Remove(movieDb);

                return Ok("Movie was deleted successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred, please contact admin.");
            }
        }
    }
}
