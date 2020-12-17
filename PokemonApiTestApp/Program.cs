﻿using PokemonApiHelper;
using PokemonApiHelper.Models.Pokemon;
using System;
using System.Threading.Tasks;

namespace PokemonApiTestApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                GetThePokemon().Wait();
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        private static async Task GetThePokemon()
        {
            await foreach (Pokemon pokemon in PokeApiHelper.GetMultiplePokemon(100).GetAsyncEnumerator())
            {
                Console.WriteLine(pokemon.Name);
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
