using System.Text.RegularExpressions;
using FirstProjects.Data;
using FirstProjects.Dtos;
using FirstProjects.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstProjects.Endpoints;

public static class GameEndpoints
{

    private const string GetGameEndPointName = "GetGame";

    public static void MapGamesEndpoints(this WebApplication app)
    {

        var group = app.MapGroup("games");

        app.MapGet("/", () => "Hello World!!");

        group.MapGet("/", async (GameStoreContext dbContext) =>
        await dbContext.Games
            .Select(item => new GameDetailsDto(
                item.Id,
                item.Name,
                item.Genre != null ? item.Genre.Name : null,
                item.Price,
                item.ReleaseDate
            ))
            .ToListAsync()
        );

        group.MapGet("/{id}", async (int id, GameStoreContext dbContext) => await dbContext.Games
        .Where(game => game.Id == id)
        .Select(game => new
        {
            game.Id,
            game.Name,
            GenreName = game.Genre != null ? game.Genre.Name : null,
            game.Price,
            game.ReleaseDate
        })
        .FirstOrDefaultAsync()
        )
        .WithName(GetGameEndPointName);

        group.MapPost("", async (CreateGameDto newGame, GameStoreContext dbContext) =>
        {
            Game game = new()
            {
                Name = newGame.name,
                GenreId = newGame.genreId,
                Price = newGame.price,
                ReleaseDate = newGame.releaseDate
            };

            dbContext.Games.Add(game);

            await dbContext.SaveChangesAsync();

            GameDto gameDto = new(
                id: game.Id,
                name: game.Name,
                GenreId: game.GenreId,
                price: game.Price,
                releaseDate: game.ReleaseDate
            );

            return Results.CreatedAtRoute(GetGameEndPointName, new { id = gameDto.id }, gameDto);
        });

        group.MapPut("/{id}", async (int id, UpdateGameDto updateGame, GameStoreContext dbContext) =>
        {
            var existingGame = await dbContext.Games.FindAsync(id);

            if (existingGame is null)
            {
                return Results.NotFound();
            }

            existingGame.Name = updateGame.name;
            existingGame.Price = updateGame.price;
            existingGame.GenreId = updateGame.genreId;
            existingGame.ReleaseDate = updateGame.releaseDate;

            await dbContext.SaveChangesAsync();

            return Results.Json(
                new
                {
                    message = "Item has been updated",
                    data = existingGame
                }
                );

        });


        group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            await dbContext.Games.Where(item => item.Id == id).ExecuteDeleteAsync();

            return Results.NoContent();

        });

    }

}
