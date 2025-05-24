

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
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public byte Star { get; set; }

        public List<FilmDto> Films { get; set; } = new List<FilmDto>();
    }

