using PokemonApiHelper.Models.Pokemon;
using System;
using System.Collections.Generic;

namespace PokemonApiTestApp
{
    class Program
    {
        private static IList<Pokemon> pokemon = new List<Pokemon>();

        private const string pokeApiUrl = @"https://pokeapi.co/api/v2/";

        private static void Main(string[] args)
        {
            try
            {
                var test = PokemonApiHelper.PokeApiHelper.GetMultiplePokemon(1);
            }
            catch (Exception ex)
            {
                LogError(ex);
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
}
