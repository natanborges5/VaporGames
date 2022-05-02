using VaporGames.Models;

namespace VaporGames.Repositories.Interfaces
{
    public interface IGameRepository
    {
        IEnumerable<Game> Games { get; }
        Game GetGameById(int id);
    }
}
