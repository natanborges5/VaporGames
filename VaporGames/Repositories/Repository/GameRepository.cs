using VaporGames.Models;
using VaporGames.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using VaporGames.Context;

namespace VaporGames.Repositories.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly AppDbContext _context;

        public GameRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Game> Games => _context.Games.Include(c => c.Genre);

        public Game GetGameById(int id)
        {
            return _context.Games.FirstOrDefault(l => l.Id ==  id); 
        }
    }
}
