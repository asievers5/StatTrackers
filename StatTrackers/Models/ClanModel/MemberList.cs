﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StatTrackers.Models
{
    public class ClanMember
    {
        public string tag { get; set; }
        public string name { get; set; }
        public string role { get; set; }
        public int expLevel { get; set; }
        public League league { get; set; }
        public int trophies { get; set; }
        public int versusTrophies { get; set; }
        public int clanRank { get; set; }
        public int previousClanRank { get; set; }
        public int donations { get; set; }
        public int donationsReceived { get; set; }
    }
}
