namespace PKMDS_Stat_Calculator.Shared;

public class RefreshService : IRefreshService
{
    public event Action? RefreshRequested;

    public void CallRequestRefresh() => RefreshRequested?.Invoke();
}
