namespace HomeBalance.Application.DTOs;

public class ExpenseResponseDto
{
    public Guid Id { get; set; }

    public decimal Amount { get; set; }

    public string Description { get; set; } = null!;

    public Guid PaidByUserId { get; set; }

    public Guid GroupId { get; set; }

    public DateTime Date { get; set; }
}