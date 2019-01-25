namespace EveIndustryStandard.Managers.Market
{
    public interface IMarketObtainer
    {
        double GetBuyingPrice(int itemId, int amount);

        double GetBuyingPriceViaBuyOrder(int itemId, int amount);

        bool CanBuyHere(int itemId, int amount);
    }
}