using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Homework1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet] 
        public IActionResult GetAll()
        {
            var response = StaticDb.Usernames;
            return Ok(response);    

        }

     

        [HttpGet("getone")]
    public IActionResult GetOne([FromQuery] int id)
    {
            var response = StaticDb.Usernames.Where(user => user.Id == id);
            return Ok(response);
    }


        }
    }


