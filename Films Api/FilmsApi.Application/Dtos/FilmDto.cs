
using FilmsApi.Core;

namespace FilmsApi.Application.Dtos;


public class FilmDto
{

    public FilmDto(Film film)
    {
        Id = film.Id;
        Name = film.Name;
        Time = film.Time;
        Star = film.Star;
        DirectorId = film.DirectorId;
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public decimal Time { get; set; }

    public byte Star { get; set; }

    public int DirectorId { get; set; }

}

