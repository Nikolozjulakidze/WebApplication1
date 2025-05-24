

using FilmsApi.Core;

namespace FilmsApi.Application.Dtos;


    public class DirectorDto
    {

        public DirectorDto(Director director)
        {
            Id = director.Id;
            Name = director.Name;
            BirthDate = director.BirthDate;
            Star = director.Star;
            Films = director.Films.Select(f => new FilmDto(f));
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public byte Star { get; set; }

        public IEnumerable<FilmDto> Films { get; set; } = new List<FilmDto>();
    }

