﻿using PokeApiCore;
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

                Console.WriteLine($"Pokemon Id: {result.id}" +
                                  $"\nName: {result.name}" +
                                  $"\nWeight (In Hectograms): {result.weight}" +
                                  $"\nHeight (In Inches): {result.height}");
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
