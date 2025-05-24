using FilmsApi.Application.Dtos;
using FilmsApi.Core;

namespace FilmsApi.Application.InterFaces;

public interface IDirectorRepository
{
    IEnumerable <Director> GetAllDirectors(int count);

    Director? GetDirectorById(int DirectorId);

    Director CreateDirector(CreateOrUpdateDirectorDto createOrUpdateDirectorDto);

    void DeleteDirector(Director director);    

    void UpdateDirector(Director director,CreateOrUpdateDirectorDto newDirector);


}
