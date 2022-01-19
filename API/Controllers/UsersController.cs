using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
namespace  API.Controllers
{
 
    public class UsersController : BaseApiController
    {
  private readonly DataContext _context;
    public UsersController(DataContext context )
    {
_context = context;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var Users = await _context.Users.ToListAsync();
        return Users;
    }
//api/users/3
    [Authorize]
      [HttpGet("{id}")] 
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        var User = await _context.Users.FindAsync(id);
        return User;
    }
    }
  
}