using PokeApiNet;

PokeApiClient pokeClient = new();

try
{
    var pokemon = GetPokemon("ho-oh").Result;
    Console.WriteLine(pokemon.Name);
}
catch (Exception ex)
{
    LogError(ex);
}

async Task<Pokemon> GetPokemon(string identifier) =>
    await pokeClient.GetResourceAsync<Pokemon>(identifier);

void LogError(Exception ex)
{
    while (true)
    {
        Console.WriteLine($"{ex.Message}{Environment.NewLine}{ex.StackTrace}");
        if (ex.InnerException != null)
        {
            ex = ex.InnerException;
            continue;
        }

        break;
    }
}
