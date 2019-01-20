using System;
using System.Collections.Generic;
using System.Linq;

namespace EveIndustryStandard.Models
{
    public class CharInfo
    {
        public int CharacterID { get; set; }

        public string CharacterName { get; set; }

        public DateTime ExpiresOn { get; set; }

        public string Scopes { get; set; }

        public List<string> ScopesList { get => Scopes.Split(' ').ToList(); }

        public string TokenType { get; set; }

        public string CharacterOwnerHash { get; set; }
    }
}
