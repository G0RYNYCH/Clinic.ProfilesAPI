using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;

namespace ProfilesAPI.Models;

[ExcludeFromCodeCoverage]
public class Account //TODO: IdentityUser<Guid>
{
    public Guid Id { get; set; }
    
    public string Email { get; set; }

    public string Password { get; set; }

    public string PhoneNumber { get; set; }

    public bool IsEmailVerified { get; set; }

    public Guid PhotoId { get; set; }

    public Account CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public Account? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }
}