using FilmsApi.Application.Dtos;

namespace FilmsApi.Application.InterFaces
{
    public interface IDirectorService
    {
        List<DirectorDto> GetDirectors(int count);
        DirectorDto? GetDirectorById(int id);
        DirectorDto CreateDirector(CreateOrUpdateDirectorDto dto);
        DirectorDto DeleteDirector(int id);

        DirectorDto UpdateDirector(int id, CreateOrUpdateDirectorDto dto);

    }
}
