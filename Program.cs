using FirstProjects.Dtos;

const string GetGameEndPointName = "GetGame";

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


List<GameDto> games = [
    new(1,
    "Street Fighter II", 19.99M, new DateOnly(1992, 7, 15)),
    new(2,
    "Final Fantasy VII", 59.99M, new DateOnly(1997, 1, 31)),
    new(3,
    "The Legend of Zelda: Ocarina of Time", 49.99M, new DateOnly(1998, 11, 21)),
    new(4,
    "Super Mario 64", 39.99M, new DateOnly(1996, 6, 23)),
    new(5,
    "Chrono Trigger", 29.99M, new DateOnly(1995, 3, 11)),
    new(6,
    "The Witcher 3: Wild Hunt", 39.99M, new DateOnly(2015, 5, 19)),
    new(7,
    "Red Dead Redemption 2", 59.99M, new DateOnly(2018, 10, 26)),
    new(8,
    "Minecraft", 26.95M, new DateOnly(2011, 11, 18)),
    new(9,
    "Elden Ring", 59.99M, new DateOnly(2022, 2, 25)),
    new(10,
     "Cyberpunk 2077", 49.99M, new DateOnly(2020, 12, 10)),
    new(11,
     "Hollow Knight", 14.99M, new DateOnly(2017, 2, 24))
];

app.MapGet("/games", () => games);
app.MapGet("/games/{id}", (int id) => games.Find(item => item.id == id))
    .WithName(GetGameEndPointName);
app.MapGet("/", () => "Hello World!!");

app.MapPost("/games", (CreateGameDto newGame) =>
{
    GameDto game = new(
        id: games.Count + 1,
        name: newGame.name,
        price: newGame.price,
        releaseDate: newGame.releaseDate
        );

    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndPointName, new { id = game.id }, game);
});

app.Run();
