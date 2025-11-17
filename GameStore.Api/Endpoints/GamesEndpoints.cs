using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndPointName = "GetGame";

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        RouteGroupBuilder game = app.MapGroup("games").WithParameterValidation();

        game.MapGet(
            "/",
            async (GameStoreContext dbContext) =>
            {
                return await dbContext
                    .Games.Include(game => game.Genre)
                    .Select(game => GameMapping.ToGameSummaryDto(game))
                    .AsNoTracking()
                    .ToListAsync();
            }
        );

        // GET /games/1
        game.MapGet(
                "{id}",
                async (int id, GameStoreContext dbContext) =>
                {
                    Game? game = await dbContext.Games.FindAsync(id);

                    return game is null ? Results.NotFound() : Results.Ok(game.ToDetailsDto());
                }
            )
            .WithName(GetGameEndPointName);

        // POST /games
        game.MapPost(
            "/",
            async (CreateGameDto newGame, GameStoreContext dbContext) =>
            {
                Game gameEntity = GameMapping.ToEntity(newGame);

                dbContext.Games.Add(gameEntity);
                await dbContext.SaveChangesAsync();

                GameDetailsDto gameDto = GameMapping.ToDetailsDto(gameEntity);

                return Results.CreatedAtRoute(
                    GetGameEndPointName,
                    new { id = gameEntity.Id },
                    gameDto
                );
            }
        );

        // PUT games/1
        game.MapPut(
            "/{id}",
            async (int id, UpdateGameDto updateGame, GameStoreContext dbContext) =>
            {
                var existingGame = await dbContext.Games.FindAsync(id);

                if (existingGame is null)
                {
                    return Results.NotFound();
                }

                dbContext
                    .Entry(existingGame)
                    .CurrentValues.SetValues(GameMapping.ToEntity(updateGame, existingGame.Id));

                await dbContext.SaveChangesAsync();

                return Results.NoContent();
            }
        );

        // DELETE games/1
        game.MapDelete(
            "/{id}",
            async (int id, GameStoreContext dbContext) =>
            {
                await dbContext.Games.Where(game => game.Id == id).ExecuteDeleteAsync();

                return Results.NoContent();
            }
        );

        return game;
    }
}
