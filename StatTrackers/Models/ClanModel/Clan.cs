using System;
using System.Collections.Generic;
using System.Text;

namespace StatTrackers.Models
{
    public class Clan
    {
        public string tag { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public Location location { get; set; }
        public BadgeUrls badgeUrls { get; set; }
        public int clanLevel { get; set; }
        public int clanPoints { get; set; }
        public int clanVersusPoints { get; set; }
        public int requiredTrophies { get; set; }
        public string warFrequency { get; set; }
        public int warWinStreak { get; set; }
        public int warWins { get; set; }
        public bool isWarLogPublic { get; set; }
        public int members { get; set; }
        public List<ClanMember> memberList { get; set; }
    }
}
