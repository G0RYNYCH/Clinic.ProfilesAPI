using System.Diagnostics.CodeAnalysis;

namespace ProfilesAPI.Models;

[ExcludeFromCodeCoverage]
public class Patient : EntityBase
{
    public bool IsLinkedToAccount { get; set; }

    public DateOnly DateOfBirth { get; set; }
}