using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult GetOne()
    {
        var response = StaticDb.Usernames.First();
        return Ok(response);
    }
        }
    }


