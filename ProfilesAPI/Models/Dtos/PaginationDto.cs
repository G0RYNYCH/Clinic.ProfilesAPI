using System.Diagnostics.CodeAnalysis;

namespace ProfilesAPI.Models.Dtos;

[ExcludeFromCodeCoverage]
public class PaginationDto
{
    public int PageSize { get; set; }
    
    public int PageNumber { get; set; }
}