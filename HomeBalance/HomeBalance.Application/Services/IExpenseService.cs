using HomeBalance.Application.DTOs;

namespace HomeBalance.Application.Services;

public interface IExpenseService
{
    Task<List<ExpenseResponseDto>> GetAllAsync();

    Task<ExpenseResponseDto> AddAsync(CreateExpenseDto dto);

    Task DeleteAsync(Guid id);
}