using VaporGames.Models;

namespace VaporGames.ViewModels
{
    public class GameListViewModel
    {
        public IEnumerable<Game> Games { get; set; }
        public string ActualGenre { get; set; }
    }
}
