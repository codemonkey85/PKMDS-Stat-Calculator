using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace PKMDS_Stat_Calculator.Components
{
    public partial class ThemeToggleButton : ComponentBase
    {
        protected override async Task OnInitializedAsync()
        {
            await ThemeService.ReadThemeFromLocalStorage(JSRuntime);
            await ThemeService.ApplyTheme(JSRuntime, RefreshService);
        }

        private async Task SetTheme(bool isDark)
        {
            await ThemeService.SetTheme(JSRuntime, RefreshService, isDark);
            RefreshService.CallRequestRefresh();
        }

        private async Task SwitchTheme() => await ThemeService.SwitchTheme(JSRuntime, RefreshService);
    }
}
