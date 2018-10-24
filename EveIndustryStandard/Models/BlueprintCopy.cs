using System.Collections.Generic;

namespace EveIndustry.Models
{
    public class Component
    {
        public int Id { get; set; }
        public int Amount { get; set; }
    }

    public class BlueprintCopy
    {
        public int MaxRuns { get; set; }

        public List<Component> RequiredComponentsForSingleRun { get; set; }
    }
}