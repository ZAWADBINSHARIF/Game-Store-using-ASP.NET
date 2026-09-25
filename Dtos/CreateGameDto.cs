namespace FirstProjects.Dtos;

public record class CreateGameDto(
int id,
string name,
decimal price,
DateOnly releaseDate
);
