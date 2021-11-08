namespace PKMDS_Stat_Calculator.Shared;

public interface IRefreshService
{
    event Action RefreshRequested;

    void CallRequestRefresh();
}
