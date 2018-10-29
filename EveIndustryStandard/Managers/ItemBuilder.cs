using System.Collections.Generic;
using EveIndustry.Models;

namespace EveIndustryStandard.Managers
{
    public class ItemBuilder
    {
        private readonly BlueprintCopy _bpc;
        public List<ItemWithAmount> Components;

        public ItemBuilder(BlueprintCopy bpc)
        {
            _bpc = bpc;
        }
    }
}