using System.ComponentModel.DataAnnotations;

namespace HomeBalance.Application.DTOs;

public class CreateExpenseDto
{
    [Required]
    public Guid GroupId { get; set; }

    [Required]
    public Guid PaidByUserId { get; set; }

    [Required]
    [Range(0.01, 100000)]
    public decimal Amount { get; set; }

    [Required]
    [MinLength(2)]
    public string Description { get; set; } = null!;
}