using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using newwone.Data;
using newwone.Model;

namespace newwone.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly FullStackDbContext _fullStackDbContext;

        public UserController(FullStackDbContext fullStackDbContext)
        {
            _fullStackDbContext = fullStackDbContext;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var user = await _fullStackDbContext.Users.ToListAsync();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User userRequest)
        {
            userRequest.UserId = Guid.NewGuid();
            await _fullStackDbContext.Users.AddAsync(userRequest);
            await _fullStackDbContext.SaveChangesAsync();
            return Ok(userRequest);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var user = await _fullStackDbContext.Users.FirstOrDefaultAsync(x => x.UserId == id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, User updateUserRequest)
        {
            var user = await _fullStackDbContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            user.UserId = updateUserRequest.UserId;
            user.name = updateUserRequest.name;
            user.Email = updateUserRequest.Email;
            user.phone = updateUserRequest.phone;
            user.Address = updateUserRequest.Address;

            await _fullStackDbContext.SaveChangesAsync();

            return Ok(user);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var user = await _fullStackDbContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            _fullStackDbContext.Users.Remove(user);
            await _fullStackDbContext.SaveChangesAsync();

            return Ok(user);
        }
    }
}
