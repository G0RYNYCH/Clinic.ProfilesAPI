﻿using System.Diagnostics.CodeAnalysis;

namespace ProfilesAPI.Models.Dtos;

[ExcludeFromCodeCoverage]
public class CreatePatientDto
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string? MiddleName { get; set; }
    
    public DateOnly DateOfBirth { get; set; }
}