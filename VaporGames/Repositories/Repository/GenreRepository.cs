using VaporGames.Context;
using VaporGames.Models;
using VaporGames.Repositories.Interfaces;

namespace VaporGames.Repositories.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly AppDbContext _context;

        public GenreRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> Genres => _context.Genres;
    }
}
