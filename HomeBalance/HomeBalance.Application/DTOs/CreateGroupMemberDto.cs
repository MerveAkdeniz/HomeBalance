using System.ComponentModel.DataAnnotations;

namespace HomeBalance.Application.DTOs;

public class CreateGroupMemberDto
{
    [Required]
    public Guid UserId { get; set; }

    [Required]
    public Guid GroupId { get; set; }

    public string Role { get; set; } = "Member";
}