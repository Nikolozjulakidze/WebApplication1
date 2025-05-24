using FilmsApi.Core;
using Microsoft.AspNetCore.Mvc;
using FilmsApi.Application.Dtos;
using FilmsApi.Application.InterFaces;
using FilmsApi.Core.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Authorize]
    [Route("films")]
    public class FilmsController:ControllerBase
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IDirectorRepository _directorRepository;
        private readonly IFilmService _filmService;
        private readonly IDirectorService _directorService;


        public FilmsController(IFilmRepository filmRepository, IDirectorRepository directorRepository,IFilmService filmService,IDirectorService directorService)
        {
            _filmRepository = filmRepository;
            _directorRepository = directorRepository;
            _filmService = filmService;
            _directorService = directorService;
        }
       

        //Query param
        [HttpGet]
        public ActionResult<IEnumerable<FilmDto>> GetFilms(int filmCount)
        {
            var films = _filmService.GetFilms(filmCount);
              
            return Ok(films);
        }

        //Route
        [HttpGet("{id}")]
        public ActionResult<Film?> GetFilm(int id)
        {
            var film = _filmService.GetFilmById(id);

            if (film == null)
            {
                throw new NotFoundException(id, nameof(film));
            }

            return Ok(film);
        }



        [HttpPost]
        public ActionResult<FilmDto> CreateFilm([FromBody] CreateOrUpdateFilmDto filmToCreate)
        {

            var director = _directorService.GetDirectorById(filmToCreate.DirectorId);

            if (director == null)
            {
                return BadRequest("Director not found.");
            }

            var film = _filmService.CreateFilm(filmToCreate);

          

            return CreatedAtAction(nameof(GetFilm), new { id = film.Id },film);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteFilm(int id)
        {
            var filmToDelete = _filmService.GetFilmById(id);

            if (filmToDelete == null)
            {
                throw new NotFoundException(id,nameof(filmToDelete));
            }

          _filmService.DeleteFilm(id);

           

            return NoContent();
        }

        //Put

        [HttpPut("{id}")]
        public ActionResult UpdateFilm(int id, [FromBody] CreateOrUpdateFilmDto newFilm)
        {
            var film = _filmService.GetFilmById(id);

            if (film == null)
            {
                throw new NotFoundException(id, nameof(film));
            }

            _filmService.UpdateFilm(id, newFilm);

            return NoContent();
        }

    }
}
