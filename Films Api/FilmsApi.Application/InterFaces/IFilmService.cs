

using FilmsApi.Application.Dtos;

namespace FilmsApi.Application.InterFaces
{
    public interface IFilmService
    {
        List<FilmDto> GetFilms(int count);
        
        FilmDto GetFilmById(int id);

        FilmDto CreateFilm(CreateOrUpdateFilmDto film);

        FilmDto UpdateFilm(int id, CreateOrUpdateFilmDto film);

        FilmDto DeleteFilm(int id);
    }
}
