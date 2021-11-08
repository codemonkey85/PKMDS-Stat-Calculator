namespace PKMDS_Stat_Calculator.Shared;

public partial class NavMenu
{
    private bool collapseNavMenu = true;

    private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu() => collapseNavMenu = !collapseNavMenu;
}
