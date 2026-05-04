using HomeBalance.Application.DTOs;
using HomeBalance.Application.Repositories;
using HomeBalance.Domain.Entities;

namespace HomeBalance.Application.Services;

public class ExpenseService : IExpenseService
{
    private readonly IExpenseRepository _repository;

    public ExpenseService(IExpenseRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ExpenseResponseDto>> GetAllAsync()
    {
        var expenses = await _repository.GetAllAsync();

        return expenses.Select(x => new ExpenseResponseDto
        {
            Id = x.Id,
            Amount = x.Amount,
            Description = x.Description,
            PaidByUserId = x.PaidByUserId,
            GroupId = x.GroupId,
            Date = x.Date
        }).ToList();
    }

    public async Task<ExpenseResponseDto> AddAsync(CreateExpenseDto dto)
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

        await _repository.AddAsync(expense);
        await _repository.SaveAsync();

        return new ExpenseResponseDto
        {
            Id = expense.Id,
            Amount = expense.Amount,
            Description = expense.Description,
            PaidByUserId = expense.PaidByUserId,
            GroupId = expense.GroupId,
            Date = expense.Date
        };
    }

    public async Task DeleteAsync(Guid id)
    {
        var expense = await _repository.GetByIdAsync(id);
        if (expense == null) return;

        await _repository.DeleteAsync(expense);
        await _repository.SaveAsync();
    }
}