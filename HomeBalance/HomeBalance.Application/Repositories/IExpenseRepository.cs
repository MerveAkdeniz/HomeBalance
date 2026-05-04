using HomeBalance.Domain.Entities;

namespace HomeBalance.Application.Repositories;

public interface IExpenseRepository
{
    Task<List<Expense>> GetAllAsync();

    Task AddAsync(Expense expense);

    Task<Expense?> GetByIdAsync(Guid id);

    Task DeleteAsync(Expense expense);

    Task SaveAsync();
}