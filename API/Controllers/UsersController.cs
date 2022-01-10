using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
namespace  API.Controllers
{
 [ApiController]
 [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
  private readonly DataContext _context;
    public UsersController(DataContext context )
    {
_context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var Users = await _context.Users.ToListAsync();
        return Users;
    }
//api/users/3
      [HttpGet("{id}")] 
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        var User = await _context.Users.FindAsync(id);
        return User;
    }
    }
  
}