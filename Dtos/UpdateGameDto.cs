namespace FirstProjects.Dtos;

public record class UpdateGameDto(
    int id,
    string name,
    decimal price,
    DateOnly releaseDate
);
