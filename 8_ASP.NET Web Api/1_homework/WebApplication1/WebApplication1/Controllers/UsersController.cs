using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<string>> Get()
        {
            return StatusCode(StatusCodes.Status200OK, StaticDb.Users);
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetUserById(int id)
        {
            try
            {
                if(id < 0 || id >= StaticDb.Users.Count)
                {
                    return NotFound("User not found");
                }

                return StatusCode(StatusCodes.Status200OK, StaticDb.Users[id]);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Please contact admin");
            }
        }
    }
}
