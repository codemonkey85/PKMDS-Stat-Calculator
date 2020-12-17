using PokemonApiHelper.Models.Pokemon;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonApiTestApp
{
    internal class Program
    {
        private static IList<Pokemon> pokemon = new List<Pokemon>();

        private const string pokeApiUrl = @"https://pokeapi.co/api/v2/";

        private static void Main(string[] args)
        {
            try
            {
                var test = GetThePokemon();
                test.Wait();
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        private static async Task GetThePokemon()
        {
            await foreach (var item in PokemonApiHelper.PokeApiHelper.GetMultiplePokemon(100).GetAsyncEnumerator())
            {
                Console.WriteLine(item.Name);
            }
        }

        private static void LogError(Exception ex)
        {
            Console.WriteLine($"{ex.Message}{Environment.NewLine}{ex.StackTrace}");
            if (ex.InnerException != null)
            {
                LogError(ex.InnerException);
            }
        }
    }

    internal static class Extensions
    {
        public static IAsyncEnumerator<T> GetAsyncEnumerator<T>(this IAsyncEnumerator<T> enumerator) => enumerator;
    }
}
