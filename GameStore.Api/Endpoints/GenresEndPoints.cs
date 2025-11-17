using System;
using GameStore.Api.Data;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.EndPoints;

public static class GenresEndPoints
{
    public static RouteGroupBuilder MapGenresEndPoints(this WebApplication app)
    {
        RouteGroupBuilder group = app.MapGroup("Genres");

        group.MapGet(
            "/",
            async (GameStoreContext dbContext) =>
            {
                return await dbContext
                    .Genres.Select(genre => genre.ToDto())
                    .AsNoTracking()
                    .ToListAsync();
            }
        );

        return group;
    }
}
