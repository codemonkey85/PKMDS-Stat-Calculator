using PokeApiNet;
using System;
using System.Threading.Tasks;

namespace PokemonApiTestApp
{
    internal class Program
    {
        private static readonly PokeApiClient pokeClient = new();

        private static void Main(string[] args)
        {
            try
            {
                Pokemon pokemon = GetPokemon("ho-oh").Result;
                Console.WriteLine(pokemon.Name);
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        private static async Task<Pokemon> GetPokemon(string identifier) => await pokeClient.GetResourceAsync<Pokemon>(identifier);

        private static async Task<Pokemon> GetPokemon(int identifier) => await pokeClient.GetResourceAsync<Pokemon>(identifier);

        private static void LogError(Exception ex)
        {
            Console.WriteLine($"{ex.Message}{Environment.NewLine}{ex.StackTrace}");
            if (ex.InnerException != null)
            {
                LogError(ex.InnerException);
            }
        }
    }
}
