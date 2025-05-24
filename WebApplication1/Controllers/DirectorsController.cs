using FilmsApi.Application.Dtos;
using FilmsApi.Application.InterFaces;
using FilmsApi.Core.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Authorize]
[Route("Directors")]
public class DirectorsController : ControllerBase
{
    private readonly IDirectorService _directorService;

    public DirectorsController(IDirectorService directorService)
    {
        _directorService = directorService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<DirectorDto>> GetDirectors(int directorCount)
    {
        var directors = _directorService.GetDirectors(directorCount);

        if (directors == null || !directors.Any())
        {
            return NotFound("No directors found.");
        }

        return Ok(directors);
    }

    [HttpGet("{id}")]
    public ActionResult<DirectorDto?> GetDirector(int id)
    {
        var director = _directorService.GetDirectorById(id);

        if (director == null)
        {
            throw new NotFoundException(id, nameof(director));
        }

        return Ok(director);
    }

    [HttpPost]
    public ActionResult<DirectorDto> CreateDirector([FromBody] CreateOrUpdateDirectorDto dto)
    {
        var director = _directorService.CreateDirector(dto);
        return CreatedAtAction(nameof(GetDirector), new { id = director.Id }, director);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteDirector(int id)
    {
        var director = _directorService.GetDirectorById(id);

        if (director == null)
        {
            throw new NotFoundException(id, nameof(director));
        }

        _directorService.DeleteDirector(id);

        return NoContent();
    }

    [HttpPut("{id}")]
    public ActionResult UpdateDirector(int id, [FromBody] CreateOrUpdateDirectorDto dto)
    {
        var director = _directorService.GetDirectorById(id);

        if (director == null)
        {
            throw new NotFoundException(id, nameof(director));
        }

        _directorService.UpdateDirector(id, dto);

        return NoContent();
    }
}
