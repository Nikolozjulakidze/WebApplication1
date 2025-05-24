using FilmsApi.Application.Dtos;
using FilmsApi.Application.InterFaces;
using FilmsApi.Core;

namespace WebApplication1.Persistence
{
    public class FilmRepository : IFilmRepository
    {
        private readonly AppDbContext _context;

        public FilmRepository(AppDbContext context)
        {
            _context = context;
        }
        public Film CreateFilm(CreateOrUpdateFilmDto createOrUpdateFilmDto)
        {
            var film = new Film()
            {
                Name = createOrUpdateFilmDto.Name,
                DirectorId = createOrUpdateFilmDto.DirectorId,
                Time = createOrUpdateFilmDto.Time,
                Star = createOrUpdateFilmDto.Star,
            };

            var createdFilm = _context.Films.Add(film);

            _context.SaveChanges();

            return createdFilm.Entity;
        }

        public void DeleteFilm(Film film)
        {
            _context.Films.Remove(film);

            _context.SaveChanges();
        }

        public IEnumerable<Film> GetAllFilms(int count)
        {
            return _context.Films
                 .Take(count);
        }

        public Film? GetFilmById(int id)
        {
            return _context.Films.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateFilm(Film film, CreateOrUpdateFilmDto newFilm)
        {
            film.Name = newFilm.Name;
            film.Time = newFilm.Time;
            film.Star = newFilm.Star;
            film.DirectorId = newFilm.DirectorId;

            _context.SaveChanges();
        }
    }
}
