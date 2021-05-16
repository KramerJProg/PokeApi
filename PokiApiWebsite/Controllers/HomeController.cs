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
            int desiredId = 1;

            Pokemon result = await PokeAPIHelper.GetById(desiredId);

            var entry = new PokedexEntryViewModel()
            {
                Id = result.Id,
                Name = result.Name,
                Height = result.Height.ToString(),
                Weight = result.Weight.ToString(),
                PokedexImageUrl = result.Sprites.FrontDefault,
                MoveList = result.moves.OrderBy(m => m.move.name)
                                       .Select(m => m.move.name)
                                       .ToArray()
            };

            entry.Name = entry.Name.First().ToString().ToUpper() + entry.Name[1..];

            return View(entry);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
