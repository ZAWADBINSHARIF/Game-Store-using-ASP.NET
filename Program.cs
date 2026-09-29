using FirstProjects.Data;
using FirstProjects.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();
builder.Services.AddSqlite<GameStoreContext>(connectionString: "Data Source=GameStore.db");

var app = builder.Build();

app.MapGamesEndpoints();

app.Run();
