using Microsoft.AspNetCore.Mvc;
using HomeBalance.Infrastructure.Data;
using HomeBalance.Domain.Entities;
using HomeBalance.Application.DTOs;

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
    public IActionResult AddItem(CreateShoppingItemDto dto)
    {
        var item = new ShoppingItem
        {
            Id = Guid.NewGuid(),
            GroupId = dto.GroupId,
            Name = dto.Name,
            IsPurchased = false
        };

        _context.ShoppingItems.Add(item);
        _context.SaveChanges();

        return Ok(item);
    }

    [HttpGet]
    public IActionResult GetItems()
    {
        return Ok(_context.ShoppingItems.ToList());
    }

    [HttpPut("{id}")]
    public IActionResult MarkAsPurchased(Guid id)
    {
        var item = _context.ShoppingItems.Find(id);
        if (item == null) return NotFound();

        item.IsPurchased = true;
        _context.SaveChanges();

        return Ok(item);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteItem(Guid id)
    {
        var item = _context.ShoppingItems.Find(id);
        if (item == null) return NotFound();

        _context.ShoppingItems.Remove(item);
        _context.SaveChanges();

        return Ok();
    }
}