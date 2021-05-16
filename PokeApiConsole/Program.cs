using PokeApiCore;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokeApiConsole
{
    class Program
    {
        static async Task Main()
        {
            PokeApiClient client = new PokeApiClient();
            try
            {
                // Pokemon result = await client.GetPokemonByName("BULBASAUR");
                Pokemon result = await client.GetPokemonById(1);

                Console.WriteLine($"Pokemon Id: {result.Id}" +
                                  $"\nName: {result.Name}" +
                                  $"\nWeight (In Hectograms): {result.Weight}" +
                                  $"\nHeight (In Inches): {result.Height}");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("I'm Sorry, that Pokemon does not exist.");
            }
            catch (HttpRequestException)
            {
                Console.WriteLine("Please try again later!");
            }
            
            Console.ReadKey();
        }
    }
}
