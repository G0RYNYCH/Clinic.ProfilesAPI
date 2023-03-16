using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;

namespace ProfilesAPI.Models;

[ExcludeFromCodeCoverage]
public class Doctor : EntityBase
{
    public DateTime DateOfBirth { get; set; }

    public Guid SpeciallizationId { get; set; }

    public Guid OfficeId { get; set; }

    public int CareerStartYear { get; set; }

    public string Status { get; set; }
}