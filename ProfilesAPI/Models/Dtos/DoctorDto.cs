using System.Diagnostics.CodeAnalysis;

namespace ProfilesAPI.Models.Dtos;

[ExcludeFromCodeCoverage]
public class DoctorDto
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string? MiddleName { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public int CareerStartYear { get; set; }
    
    public Guid SpeciallizationId { get; set; }

    public Guid OfficeId { get; set; }
}