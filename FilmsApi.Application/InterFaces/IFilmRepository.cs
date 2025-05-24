using FilmsApi.Application.Dtos;
using FilmsApi.Core;



namespace FilmsApi.Application.InterFaces;

public interface IFilmRepository
{
    IEnumerable<Film> GetAllFilms(int count);

    Film? GetFilmById(int filmId);

    Film CreateFilm(CreateOrUpdateFilmDto createOrUpdateFilmDto);

    void DeleteFilm(Film film);

    void UpdateFilm(Film film,CreateOrUpdateFilmDto newFilm);

}
