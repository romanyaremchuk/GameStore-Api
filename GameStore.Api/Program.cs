using GameStore.Api.Data;
using GameStore.Api.Endpoints;
using GameStore.Api.EndPoints;

var builder = WebApplication.CreateBuilder(args);

string connString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connString);

var app = builder.Build();

app.MapGamesEndpoints();
app.MapGenresEndPoints();

await app.MigrateDbAsync();

app.Run();
