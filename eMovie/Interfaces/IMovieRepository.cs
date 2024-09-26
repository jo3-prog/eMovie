using eMovie.Models;

namespace eMovie.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAll();
        Task<IEnumerable<Movie>> GetMovie(string search);
        Task<Movie> GetByIdAsync(int id);
        bool Add(Movie movie);
        bool Update(Movie movie);
        bool Delete(Movie movie);
        bool Save();
    }
}
