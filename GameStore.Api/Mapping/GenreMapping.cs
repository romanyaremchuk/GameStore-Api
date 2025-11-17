using GameStore.Api.Dtos;
using GameStore.Api.Entities;

namespace GameStore.Api.Mapping;

public static class GenreMapping
{
    public static Genre ToEntity(this GenreDto genreDto)
    {
        return new() { Id = genreDto.Id, Name = genreDto.Name };
    }

    public static GenreDto ToDto(this Genre genre)
    {
        return new GenreDto(genre.Id, genre.Name);
    }
}
