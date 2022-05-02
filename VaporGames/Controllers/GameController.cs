using Microsoft.AspNetCore.Mvc;
using VaporGames.Models;
using VaporGames.Repositories.Interfaces;
using VaporGames.ViewModels;

namespace VaporGames.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameRepository gameRepository;

        public GameController(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public IActionResult List(string genre)
        {
            IEnumerable<Game> games;
            string actualGenre = string.Empty;
            if (string.IsNullOrEmpty(genre))
            {
                games = gameRepository.Games.OrderBy(x => x.Name);
                actualGenre = "All Games";
            }
            else
            {
                games = gameRepository.Games.Where(g => g.Genre.Name == genre.ToUpper()).OrderBy(g => g.Name);
                if (games.Any())
                {
                    actualGenre = genre;
                }
                else
                {
                    actualGenre = "Categoria Invalida";
                }
                
            }
            var gamesListViewModel = new GameListViewModel
            {
                Games = games,
                ActualGenre = actualGenre,
            };
            

            ViewBag.TotalGames = gamesListViewModel.Games.Count();
            return View(gamesListViewModel);
        }
        public IActionResult Details(int gameId)
        {
            var game = gameRepository.Games.FirstOrDefault(g => g.Id == gameId);
            return View(game);
        }
        public IActionResult Search(string searchString)
        {
            IEnumerable<Game> games;
            string actualCategory = string.Empty;
            if (string.IsNullOrEmpty(searchString))
            {
                games = gameRepository.Games.OrderBy(g => g.Name);
                actualCategory = "All Games";

            }
            else
            {
                games = gameRepository.Games.Where(g => g.Name.ToLower().Contains(searchString.ToLower()));
                if (games.Any())
                {
                    actualCategory = searchString;
                }
                else
                {
                    actualCategory = "None";
                }
            }
            return View("~/Views/Game/List.cshtml", new GameListViewModel
            {
                Games = games,
                ActualGenre = actualCategory,
            });
        }
    }
}
