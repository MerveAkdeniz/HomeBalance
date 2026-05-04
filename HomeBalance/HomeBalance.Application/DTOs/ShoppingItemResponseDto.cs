namespace HomeBalance.Application.DTOs;

public class ShoppingItemResponseDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsPurchased { get; set; }

    public Guid GroupId { get; set; }
}