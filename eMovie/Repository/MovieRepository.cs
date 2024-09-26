using eMovie.Data;
using eMovie.Interfaces;
using eMovie.Models;
using Microsoft.EntityFrameworkCore;

namespace eMovie.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;
        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Movie movie)
        {
            _context.Add(movie);
            return Save();
        }

        public bool Delete(Movie movie)
        {
            _context.Remove(movie);
            return Save();
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _context.Movies.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Movie>> GetMovie(string search)
        {
            return await _context.Movies.Where(m => m.Title.Contains(search)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Movie movie)
        {
            _context.Update(movie);
            return Save();
        }
    }
}
