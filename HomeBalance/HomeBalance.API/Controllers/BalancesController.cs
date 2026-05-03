using Microsoft.AspNetCore.Mvc;
using HomeBalance.Infrastructure.Data;

namespace HomeBalance.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BalancesController : ControllerBase
{
    private readonly AppDbContext _context;

    public BalancesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("{groupId}")]
    public IActionResult CalculateBalance(Guid groupId)
    {
        var members = _context.GroupMembers
            .Where(x => x.GroupId == groupId)
            .Select(x => x.UserId)
            .ToList();

        var expenses = _context.Expenses
            .Where(x => x.GroupId == groupId)
            .ToList();

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