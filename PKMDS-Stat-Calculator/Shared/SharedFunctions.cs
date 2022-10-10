using Microsoft.JSInterop;

namespace PKMDS_Stat_Calculator.Shared;

public static class SharedFunctions
{
    public static async Task ChangeTheme(this IJSRuntime jsRuntime, bool isDark) =>
        await jsRuntime.InvokeVoidAsync("changeTheme", isDark);

    public static async Task AddToLocalStorage<T>(this IJSRuntime jsRuntime, string key, T value) =>
        await jsRuntime.InvokeVoidAsync("addToLocalStorage", key, value);

    public static async Task<string> ReadFromLocalStorage(this IJSRuntime jsRuntime, string key,
        string? valueIfMissing = null) =>
        await jsRuntime.InvokeAsync<string>("readFromLocalStorage", key, valueIfMissing);
}
