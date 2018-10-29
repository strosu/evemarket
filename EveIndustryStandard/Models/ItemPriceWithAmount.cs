namespace EveIndustry.Models
{
    public class ItemPriceWithAmount
    {
        public int Amount { get; set; }
        public ItemPrice Item { get; set; }
    }

    public class ItemWithAmount
    {
        public int Amount { get; set; }
        public Item Item { get; set; }
    }
}