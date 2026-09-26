namespace FirstProjects.Dtos;

public record class GameDto(
    int id,
    string name,
    decimal price,
    DateOnly releaseDate
);
