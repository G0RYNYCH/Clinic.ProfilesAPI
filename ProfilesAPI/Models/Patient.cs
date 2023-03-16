using System.Diagnostics.CodeAnalysis;

namespace ProfilesAPI.Models;

[ExcludeFromCodeCoverage]
public class Patient : EntityBase
{
    public bool IsLinkedToAccount { get; set; }

    public DateTime DateOfBirth { get; set; }
}