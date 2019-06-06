using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace StatTrackers
{
    public static class StaticVariables
    {
        // Enter ClanTag, Token, and AllowedIPAddress
        public static string ClanTag = "";

        public static string Token = "";

        public static List<string> AllowedIPAddresses = new List<string> { "" };

        public static HttpClient client = new HttpClient();

    }
}
