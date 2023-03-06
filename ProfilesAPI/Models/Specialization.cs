using System.Diagnostics.CodeAnalysis;

namespace ProfilesAPI.Models;

[ExcludeFromCodeCoverage]
public class Specialization
{
    public Guid Id { get; set; }

    public string SpecializationName { get; set; }

    public bool IsActive { get; set; }
}