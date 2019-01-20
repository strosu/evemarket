using System.Collections.Generic;

namespace EveIndustryStandard.Models
{
    public struct Component
    {
        public int Id { get; set; }
        public int Amount { get; set; }
    }

    public class BlueprintCopy
    {
        public int MaxRuns { get; set; }

        public List<Component> UnresearchedRequiredComponentsForSingleRun { get; set; }
    }
}