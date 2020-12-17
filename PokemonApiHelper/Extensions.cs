using System.Collections.Generic;

namespace PokemonApiHelper
{
    public static class Extensions
    {
        public static IAsyncEnumerator<T> GetAsyncEnumerator<T>(this IAsyncEnumerator<T> enumerator) => enumerator;
    }
}
