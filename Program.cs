using FirstProjects.Data;
using FirstProjects.Endpoints;
using FirstProjects.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();
builder.AddGameStoreDB();

var app = builder.Build();

app.MapGamesEndpoints();
app.MigrateDb();

app.Run();
