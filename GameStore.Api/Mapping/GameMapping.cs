using GameStore.Api.Dtos;
using GameStore.Api.Entities;

namespace GameStore.Api.Mapping;

public static class GameMapping
{
    public static Game ToEntity(this CreateGameDto gameDto)
    {
        return new()
        {
            Name = gameDto.Name,
            GenreId = gameDto.GenreId,
            Price = gameDto.Price,
            ReleaseDate = gameDto.ReleaseDate,
        };
    }

    public static Game ToEntity(this UpdateGameDto gameDto, int gameId)
    {
        return new()
        {
            Id = gameId,
            Name = gameDto.Name,
            GenreId = gameDto.GenreId,
            Price = gameDto.Price,
            ReleaseDate = gameDto.ReleaseDate,
        };
    }

    public static GameDetailsDto ToDetailsDto(this Game game)
    {
        return new GameDetailsDto(
            Id: game.Id,
            Name: game.Name,
            GenreId: game.GenreId,
            Price: game.Price,
            ReleaseDate: game.ReleaseDate
        );
    }

    public static GameSummaryDto ToGameSummaryDto(this Game game)
    {
        return new GameSummaryDto(
            Id: game.Id,
            Name: game.Name,
            Genre: game.Genre!.Name,
            Price: game.Price,
            ReleaseDate: game.ReleaseDate
        );
    }
}
