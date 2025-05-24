using FilmsApi.Application.Dtos;
using FilmsApi.Application.InterFaces;
using FilmsApi.Core;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Persistence
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly AppDbContext _context;

        public DirectorRepository(AppDbContext context)
        {
            _context = context;
        }
        public Director CreateDirector(CreateOrUpdateDirectorDto createOrUpdateDirectorDto)
        {
            var director = new Director()
            {
                Name = createOrUpdateDirectorDto.Name,
                BirthDate = createOrUpdateDirectorDto.BirthDate,
                Star = createOrUpdateDirectorDto.Star,
            };

            var createdDirector = _context.Directors.Add(director);

            _context.SaveChanges();

            return createdDirector.Entity;

        }

        public void DeleteDirector(Director director)
        {
            _context.Directors.Remove(director);

            _context.SaveChanges();
        }

        public IEnumerable<Director> GetAllDirectors(int count)
        {
            return _context.Directors.Include(f => f.Films);
                 
        }

        public Director? GetDirectorById(int id)
        {
            return _context.Directors.Include(f => f.Films)
                .FirstOrDefault(x => x.Id == id);
        }

        public void UpdateDirector(Director director, CreateOrUpdateDirectorDto newDirector)
        {
            director.Name = newDirector.Name;
            director.BirthDate = newDirector.BirthDate;
            director.Star = newDirector.Star;

            _context.SaveChanges();
        }
    }
}
