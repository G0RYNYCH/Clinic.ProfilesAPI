using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;

namespace ProfilesAPI.Models;

[ExcludeFromCodeCoverage]
public class Doctor //: IdentityUser<Guid>
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string? MiddleName { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public Guid AccountId { get; set; }
    
    public Guid SpeciallizationId { get; set; }
    
    public Guid OfficeId { get; set; }

    public int CareerStartYear { get; set; }

    public string Status { get; set; }
}