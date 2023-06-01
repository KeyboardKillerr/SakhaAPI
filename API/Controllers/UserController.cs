using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataModels.Entities;
using DataModels;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using API.Controllers.PostEntities;

namespace API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUsers()
        {
            var ctx = Context.Get();
            IEnumerable<User> Users = await ctx.User.Items.ToListAsync();
            return Ok(Users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var ctx = Context.Get();

            var user = await ctx.User.GetItemByIdAsync(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpGet("{email}/{password}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AuthUser(string email, string password)
        {
            var ctx = Context.Get();

            var user = await ctx.User.Items.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            return user == default ? NotFound() : Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser(UserPost userinfo)
        {
            var ctx = Context.Get();

            var user = new User();
            user.Name = userinfo.Name;
            user.Email = userinfo.Email;
            user.Password = userinfo.Password;

            var result = await ctx.User.CreateAsync(user);
            if (result == 0) return BadRequest();
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUser(Guid id, User user)
        {
            var ctx = Context.Get();

            if (id != user.Id) return BadRequest();
            var result = await ctx.User.UpdateAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var ctx = Context.Get();

            var result = await ctx.User.DeleteAsync(id);
            if (result == 0) return BadRequest();
            return NoContent();
        }
    }
}
