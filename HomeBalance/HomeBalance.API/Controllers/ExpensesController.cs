using Microsoft.AspNetCore.Mvc;
using HomeBalance.Infrastructure.Data;
using HomeBalance.Domain.Entities;
using HomeBalance.Application.DTOs;

namespace HomeBalance.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpensesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ExpensesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AddExpense(CreateExpenseDto dto)
    {
        var expense = new Expense
        {
            Id = Guid.NewGuid(),
            GroupId = dto.GroupId,
            PaidByUserId = dto.PaidByUserId,
            Amount = dto.Amount,
            Description = dto.Description,
            Date = DateTime.UtcNow
        };

        _context.Expenses.Add(expense);
        _context.SaveChanges();

        return Ok(expense);
    }

    [HttpGet]
    public IActionResult GetExpenses()
    {
        return Ok(_context.Expenses.ToList());
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteExpense(Guid id)
    {
        var expense = _context.Expenses.Find(id);
        if (expense == null) return NotFound();

        _context.Expenses.Remove(expense);
        _context.SaveChanges();

        return Ok();
    }
}