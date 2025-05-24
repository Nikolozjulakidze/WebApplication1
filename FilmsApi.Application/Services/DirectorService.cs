using FilmsApi.Application.Dtos;
using FilmsApi.Application.InterFaces;

namespace FilmsApi.Application.Services
{
    public class DirectorService : IDirectorService
    {
        private readonly IDirectorRepository _repository;

        public DirectorService(IDirectorRepository directorRepository)
        {
            _repository = directorRepository;
        }

        public List<DirectorDto> GetDirectors(int count)
        {
            return _repository.GetAllDirectors(count)
                .Select(d => new DirectorDto(d))
                .ToList();
        }

        public DirectorDto? GetDirectorById(int id)
        {
            var director = _repository.GetDirectorById(id);
            return director == null ? null : new DirectorDto(director);

        }

        public DirectorDto CreateDirector(CreateOrUpdateDirectorDto dto)
        {
            var director = _repository.CreateDirector(dto);
            return new DirectorDto(director);
        }

        public DirectorDto UpdateDirector(int id,CreateOrUpdateDirectorDto dto)
        {
            var director = _repository.GetDirectorById(id);
            if(director == null)
            {
                throw new Exception("Director not found");
            }

            _repository.UpdateDirector(director,dto);
            return new DirectorDto(director);

        }

        public DirectorDto DeleteDirector(int id)
        {
            var director = _repository.GetDirectorById(id);
            if (director == null)
            {
                throw new Exception("Director not found.");
            }

            _repository.DeleteDirector(director);
            return new DirectorDto(director);
        }

     
    }
}
