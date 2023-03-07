using System.Diagnostics.CodeAnalysis;

namespace ProfilesAPI.Models;

[ExcludeFromCodeCoverage]
public class Receptionist : EntityBase
{
    public Guid OfficeId { get; set; }
}