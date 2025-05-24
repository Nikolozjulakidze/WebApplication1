
using FilmsApi.Application.Dtos;
using FilmsApi.Application.InterFaces;

namespace FilmsApi.Application.Services;

public class FilmService:IFilmService
{
    private readonly IFilmRepository _filmRepository;

    public FilmService(IFilmRepository filmRepository)
    {
        _filmRepository = filmRepository;
    }

    public List<FilmDto> GetFilms(int count)
    {
        return _filmRepository.GetAllFilms(count)
            .Select(f => new FilmDto(f))
            .ToList();
    }

    public FilmDto? GetFilmById(int id)
    {
        var film = _filmRepository.GetFilmById(id);

        return new FilmDto(film);   
    }

    public FilmDto? CreateFilm(CreateOrUpdateFilmDto film)
    {
        var Createdfilm = _filmRepository.CreateFilm(film);

        return new FilmDto(Createdfilm);
    }

    public FilmDto UpdateFilm(int id, CreateOrUpdateFilmDto filmDto)
    {
        var film = _filmRepository.GetFilmById(id);

        if (film == null)
        {
            throw new Exception("Film not found"); 
        }

        _filmRepository.UpdateFilm(film, filmDto);

        return new FilmDto(film);
    }


    public FilmDto DeleteFilm(int id)
    {
        var film = _filmRepository.GetFilmById(id);
        if (film == null)
        {
            throw new Exception("Film not found");
        }

        _filmRepository.DeleteFilm(film);
        return new FilmDto(film);
    }
}
