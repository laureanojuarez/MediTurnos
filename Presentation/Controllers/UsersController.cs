using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet]
    public ActionResult<List<UserDto>> Get()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }
}