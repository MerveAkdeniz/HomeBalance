using Microsoft.AspNetCore.Mvc;
using HomeBalance.Infrastructure.Data;
using HomeBalance.Domain.Entities;
using HomeBalance.Application.DTOs;

namespace HomeBalance.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupsController : ControllerBase
{
    private readonly AppDbContext _context;

    public GroupsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult CreateGroup(CreateGroupDto dto)
    {
        var group = new Group
        {
            Id = Guid.NewGuid(),
            Name = dto.Name
        };

        _context.Groups.Add(group);
        _context.SaveChanges();

        return Ok(group);
    }

    [HttpGet]
    public IActionResult GetGroups()
    {
        return Ok(_context.Groups.ToList());
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteGroup(Guid id)
    {
        var group = _context.Groups.Find(id);
        if (group == null) return NotFound();

        _context.Groups.Remove(group);
        _context.SaveChanges();

        return Ok();
    }
}