using System.ComponentModel.DataAnnotations;

namespace FirstProjects.Dtos;

public record class UpdateGameDto(
    int id,
    [Required][MinLength(3)][MaxLength(50)] string name,
    [Range(1, 99)] decimal price,
    int genreId,
    DateOnly releaseDate
);
