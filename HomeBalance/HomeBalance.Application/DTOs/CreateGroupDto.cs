using System.ComponentModel.DataAnnotations;

namespace HomeBalance.Application.DTOs;

public class CreateGroupDto
{
    [Required]
    [MinLength(2)]
    public string Name { get; set; } = null!;
}