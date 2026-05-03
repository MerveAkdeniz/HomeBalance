using System.ComponentModel.DataAnnotations;

namespace HomeBalance.Application.DTOs;

public class CreateShoppingItemDto
{
    [Required]
    public Guid GroupId { get; set; }

    [Required]
    [MinLength(2)]
    public string Name { get; set; } = null!;
}