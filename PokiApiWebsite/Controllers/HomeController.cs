using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PokeApiCore;
using PokiApiWebsite.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PokiApiWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            PokeApiClient myCLient = new PokeApiClient();
            Pokemon result = await myCLient.GetPokemonById(1);

            List<string> resultMoves = new List<string>();
            foreach (Move currMove in result.moves)
            {
                resultMoves.Add(currMove.move.name);
            }

            resultMoves.Sort();

            // Add move list
            // Refactor prop names
            PokedexEntryViewModel entry = new PokedexEntryViewModel()
            {
                Id = result.id,
                Name = result.Name,
                Height = result.Height.ToString(),
                Weight = result.Weight.ToString(),
                PokedexImageUrl = result.sprites.FrontDefault,
                MoveList = resultMoves
            };

            return View(entry);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
