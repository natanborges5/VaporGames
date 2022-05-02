using VaporGames.Models;

namespace VaporGames.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> Genres { get; }
    }
}
