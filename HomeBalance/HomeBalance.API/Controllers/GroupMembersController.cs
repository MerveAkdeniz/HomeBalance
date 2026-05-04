using Microsoft.AspNetCore.Mvc;
using HomeBalance.Infrastructure.Data;
using HomeBalance.Domain.Entities;
using HomeBalance.Application.DTOs;
using Microsoft.EntityFrameworkCore;

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
    public async Task<IActionResult> AddMember(CreateGroupMemberDto dto)
    {
        var member = new GroupMember
        {
            Id = Guid.NewGuid(),
            UserId = dto.UserId,
            GroupId = dto.GroupId,
            Role = dto.Role
        };

        _context.GroupMembers.Add(member);
        await _context.SaveChangesAsync();

        return Ok(member);
    }

    [HttpGet]
    public async Task<IActionResult> GetMembers()
    {
        var members = await _context.GroupMembers.ToListAsync();
        return Ok(members);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMember(Guid id)
    {
        var member = await _context.GroupMembers.FindAsync(id);
        if (member == null) return NotFound();

        _context.GroupMembers.Remove(member);
        await _context.SaveChangesAsync();

        return Ok();
    }
}