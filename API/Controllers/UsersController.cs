using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using API.Interfaces;
using System.Net.Http;
using API.DTOs;
using AutoMapper;

namespace  API.Controllers
{
 [Authorize]
    public class UsersController : BaseApiController
    {
 
  private readonly IUserRepository _userRepository;
  private readonly IMapper _mapper;
    public UsersController(IUserRepository userRepository , IMapper mapper)
    {
_userRepository= userRepository;
_mapper= mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
       var users= await _userRepository.GetMembersAsync();
        return Ok(users);
    }
//api/users/3
      [HttpGet("{username}")] 
    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {
        return await _userRepository.GetMemberAsync(username);
    }
    }
  
}