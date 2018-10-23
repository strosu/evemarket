using System.Diagnostics.CodeAnalysis;

namespace EveIndustry.Models
{
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    public class ItemPrice
    {
        public int ItemId { get; set; }

        public double JitaSellPrice { get; set; }

        public double OneDqSellPrice { get; set; }
    }
}