using System.ComponentModel.DataAnnotations;

namespace FirstProjects.Dtos;

public record class CreateGameDto(
    [Required][MinLength(3)][MaxLength(50)] string name,
    int genreId,
    [Range(1, 99)] decimal price,
    DateOnly releaseDate
);
