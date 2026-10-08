using System.Diagnostics.CodeAnalysis;

namespace FirstProjects.Dtos;

public record class GameDetailsDto(
    int id,
    string name,
    string? Genre,
    decimal price,
    DateOnly releaseDate
);
