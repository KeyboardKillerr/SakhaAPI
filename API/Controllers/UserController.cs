using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataModels.Entities;

namespace API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            IEnumerable<User> Users = Context.Data.User.Items;
            return Ok(Users);
        }
    }
}
