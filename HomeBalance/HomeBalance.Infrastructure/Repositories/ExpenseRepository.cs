using HomeBalance.Application.Repositories;
using HomeBalance.Domain.Entities;
using HomeBalance.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HomeBalance.Infrastructure.Repositories;

public class ExpenseRepository : IExpenseRepository
{
    private readonly AppDbContext _context;

    public ExpenseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Expense>> GetAllAsync()
    {
        return await _context.Expenses.ToListAsync();
    }

    public async Task AddAsync(Expense expense)
    {
        await _context.Expenses.AddAsync(expense);
    }

    public async Task<Expense?> GetByIdAsync(Guid id)
    {
        return await _context.Expenses.FindAsync(id);
    }

    public async Task DeleteAsync(Expense expense)
    {
        _context.Expenses.Remove(expense);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}