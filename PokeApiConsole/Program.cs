using PokeApiCore;
using System;
using System.Threading.Tasks;

namespace PokeApiConsole
{
    class Program
    {
        static async Task Main()
        {
            PokeApiClient client = new PokeApiClient();
            Pokemon result = await client.GetPokemonByName("bulbasaur");

            Console.WriteLine($"Pokemon Id: {result.id}" +
                              $"\nName: {result.name}" +
                              $"\nWeight (In Hectograms): {result.weight}" +
                              $"\nHeight (In Inches): {result.height}");

            Console.ReadKey();
        }
    }
}
