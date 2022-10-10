using Microsoft.JSInterop;

namespace PKMDS_Stat_Calculator.Shared;

public interface IThemeService
{
    Task ReadThemeFromLocalStorage(IJSRuntime jSRuntime);

    Task WriteThemeToLocalStorage(IJSRuntime jSRuntime);

    Task SetTheme(IJSRuntime jsRuntime, IRefreshService refreshService, bool isDark);

    Task ApplyTheme(IJSRuntime jSRuntime, IRefreshService refreshService);

    Task SwitchTheme(IJSRuntime jsRuntime, IRefreshService refreshService);
}
