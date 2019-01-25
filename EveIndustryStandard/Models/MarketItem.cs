namespace EveIndustryStandard.Models
{
    public class MarketItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MarketGroup { get; set; }

        public int Group { get; set; }

        public float Volume { get; set; }
    }
}