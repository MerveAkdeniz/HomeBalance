using Microsoft.AspNetCore.Mvc;
using HomeBalance.Infrastructure.Data;
using HomeBalance.Domain.Entities;
using HomeBalance.Application.DTOs;

namespace HomeBalance.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupMembersController : ControllerBase
{
    private readonly AppDbContext _context;

    public GroupMembersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AddMember(CreateGroupMemberDto dto)
    {
        var member = new GroupMember
        {
            Id = Guid.NewGuid(),
            UserId = dto.UserId,
            GroupId = dto.GroupId,
            Role = dto.Role
        };

        _context.GroupMembers.Add(member);
        _context.SaveChanges();

        return Ok(member);
    }

    [HttpGet]
    public IActionResult GetMembers()
    {
        return Ok(_context.GroupMembers.ToList());
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMember(Guid id)
    {
        var member = _context.GroupMembers.Find(id);
        if (member == null) return NotFound();

        _context.GroupMembers.Remove(member);
        _context.SaveChanges();

        return Ok();
    }
}