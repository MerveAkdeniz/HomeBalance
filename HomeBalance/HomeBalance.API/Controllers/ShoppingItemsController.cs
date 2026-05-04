using Microsoft.AspNetCore.Mvc;
using HomeBalance.Infrastructure.Data;
using HomeBalance.Domain.Entities;
using HomeBalance.Application.DTOs;
using Microsoft.EntityFrameworkCore;

namespace HomeBalance.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShoppingItemsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ShoppingItemsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> AddItem(CreateShoppingItemDto dto)
    {
        var item = new ShoppingItem
        {
            Id = Guid.NewGuid(),
            GroupId = dto.GroupId,
            Name = dto.Name,
            IsPurchased = false
        };

        _context.ShoppingItems.Add(item);
        await _context.SaveChangesAsync();

        var response = new ShoppingItemResponseDto
        {
            Id = item.Id,
            Name = item.Name,
            IsPurchased = item.IsPurchased,
            GroupId = item.GroupId
        };

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetItems()
    {
        var items = await _context.ShoppingItems.ToListAsync();
        var response = items.Select(x => new ShoppingItemResponseDto
        {
            Id = x.Id,
            Name = x.Name,
            IsPurchased = x.IsPurchased,
            GroupId = x.GroupId
        }).ToList();

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> MarkAsPurchased(Guid id)
    {
        var item = await _context.ShoppingItems.FindAsync(id);
        if (item == null) return NotFound();

        item.IsPurchased = true;
        await _context.SaveChangesAsync();

        return Ok(item);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteItem(Guid id)
    {
        var item = await _context.ShoppingItems.FindAsync(id);
        if (item == null) return NotFound();

        _context.ShoppingItems.Remove(item);
        await _context.SaveChangesAsync();

        return Ok();
    }
}