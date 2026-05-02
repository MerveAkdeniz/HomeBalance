using Microsoft.AspNetCore.Mvc;
using HomeBalance.Infrastructure.Data;
using HomeBalance.Domain.Entities;

namespace HomeBalance.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult CreateUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();

        return Ok(user);
    }
    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = _context.Users.ToList();
        return Ok(users);
    }
}