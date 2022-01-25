using API.Data;
using Microsoft.AspNetCore.Authorization;
using API.Entities;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
namespace  API.Controllers
{
    public class BuggyController :BaseApiController
    {
        private readonly DataContext _context;
        public BuggyController(DataContext context)
        {
            _context= context;
        }
        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "Secret Text";
        }
         [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var thing = _context.Users.Find(-1);
            if(thing==null)
            return NotFound();
            return Ok(thing);
        }
         [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var thing= _context.Users.Find(-1);

            var thningToReturn = thing.ToString();
             return thningToReturn;
        }
         [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This was not a good request");
        }
    }
       
}