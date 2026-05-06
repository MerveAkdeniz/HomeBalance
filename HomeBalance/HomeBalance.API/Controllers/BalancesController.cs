using Microsoft.AspNetCore.Mvc;
using HomeBalance.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace HomeBalance.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class BalancesController : ControllerBase
{
    private readonly AppDbContext _context;

    public BalancesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("{groupId}")]
    public async Task<IActionResult> CalculateBalance(Guid groupId)
    {
        var members = await _context.GroupMembers
            .Where(x => x.GroupId == groupId)
            .Select(x => x.UserId)
            .ToListAsync();

        var expenses = await _context.Expenses
            .Where(x => x.GroupId == groupId)
            .ToListAsync();

        if (!members.Any())
            return BadRequest("No members");

        var totalExpense = expenses.Sum(x => x.Amount);
        var perPerson = totalExpense / members.Count;

        var result = new List<object>();

        foreach (var userId in members)
        {
            var paid = expenses
                .Where(x => x.PaidByUserId == userId)
                .Sum(x => x.Amount);

            var balance = paid - perPerson;

            result.Add(new
            {
                UserId = userId,
                Paid = paid,
                ShouldPay = perPerson,
                Balance = balance
            });
        }

        return Ok(result);
    }
}