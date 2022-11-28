using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using TodoApi.Core.Database;
using TodoApi.Core.Entities;
using TodoApi.DataObjects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly TodoContext _todoContext;
        private readonly IMapper _mapper;
        public UserController(TodoContext todoContext, IMapper mapper)
        {
            _mapper = mapper;
            _todoContext = todoContext;
        }
        [HttpPost]
        public async Task<IActionResult> Authentication(UserDTO userDTO)
        {
            var user = await _todoContext.Users.FirstOrDefaultAsync(x => x.Email == userDTO.Email);
            if (user != null && user.Password == userDTO.Password) return Ok(user.Id);
            else return BadRequest("Wrong password or email");
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            var email = await _todoContext.Users.Where(x => x.Email == userDTO.Email).Select(x => x.Email).FirstOrDefaultAsync();
            if (email != null) return BadRequest($"{email} was used");
            else
            {
                var user = _mapper.Map<User>(userDTO);
                await _todoContext.AddAsync(user);
                await _todoContext.SaveChangesAsync();
                return CreatedAtAction(nameof(Register),user.Id);
            }
        }
        [HttpGet]
        public IActionResult Hello()
        {
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var user = await _todoContext.Users.AsNoTracking().Include(x => x.Calendar).ThenInclude(x => x.Works).ToListAsync();
            if (user != null) return Ok(user);
            else return NotFound("Not Found user");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _todoContext.Users.AsNoTracking().Include(x => x.Calendar).ThenInclude(x => x.Works).FirstOrDefaultAsync(x => x.Id == id);
            if(user!=null) return Ok(user);
            else return NotFound("Not Found user");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UserDTO userDTO,[FromRoute] int id)
        {
            var user = await _todoContext.Users.FindAsync(id);
            if (user is null) return NotFound();
            else
            {
                _mapper.Map(userDTO,user);
                await _todoContext.SaveChangesAsync();
                return Ok("Update Success");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _todoContext.Users.FindAsync(id);
            if (user is null) return NotFound();
            else
            {
                _todoContext.Users.Remove(user);
                await _todoContext.SaveChangesAsync();
                return Ok("Delete Success");
            }
        }
    }
}
