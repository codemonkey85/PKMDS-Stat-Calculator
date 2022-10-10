using Microsoft.JSInterop;

namespace PKMDS_Stat_Calculator.Shared;

public class ThemeService : IThemeService
{
    private bool _isDarkTheme;
    private const string IsDarkThemeKey = @"isDarkTheme";

    public async Task ReadThemeFromLocalStorage(IJSRuntime jSRuntime) =>
        _isDarkTheme = int.Parse(await jSRuntime.ReadFromLocalStorage(IsDarkThemeKey, "0")) == 1;

    public async Task WriteThemeToLocalStorage(IJSRuntime jSRuntime) =>
        await jSRuntime.AddToLocalStorage(IsDarkThemeKey, _isDarkTheme ? 1 : 0);

    public async Task SetTheme(IJSRuntime jSRuntime, IRefreshService refreshService, bool isDark)
    {
        _isDarkTheme = isDark;
        await WriteThemeToLocalStorage(jSRuntime);
        await ApplyTheme(jSRuntime, refreshService);
    }

    public async Task ApplyTheme(IJSRuntime jSRuntime, IRefreshService refreshService)
    {
        await jSRuntime.ChangeTheme(_isDarkTheme);
        refreshService.CallRequestRefresh();
    }

    public async Task SwitchTheme(IJSRuntime jSRuntime, IRefreshService refreshService) =>
        await SetTheme(jSRuntime, refreshService, !_isDarkTheme);
}
