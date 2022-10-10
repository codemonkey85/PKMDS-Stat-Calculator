namespace PKMDS_Stat_Calculator.Components;

public partial class ThemeToggleButton : ComponentBase
{
    protected override async Task OnInitializedAsync()
    {
        await ThemeService.ReadThemeFromLocalStorage(JsRuntime);
        await ThemeService.ApplyTheme(JsRuntime, RefreshService);
    }

    private async Task SetTheme(bool isDark)
    {
        await ThemeService.SetTheme(JsRuntime, RefreshService, isDark);
        RefreshService.CallRequestRefresh();
    }

    private async Task SwitchTheme() => await ThemeService.SwitchTheme(JsRuntime, RefreshService);
}
