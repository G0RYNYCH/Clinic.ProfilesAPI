using System.Diagnostics.CodeAnalysis;

namespace ProfilesAPI.Models;

[ExcludeFromCodeCoverage]
public abstract class EntityBase
{
    public Guid Id { get; set; }
    
    public Guid AccountId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string? MiddleName { get; set; }
}