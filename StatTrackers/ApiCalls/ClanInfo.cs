using Newtonsoft.Json;
using StatTrackers.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StatTrackers.Controllers
{
    public class ClanInfo
    {
        public string Name { get; set; }
        public string Tag { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int ClanLevel { get; set; }
        public int ClanPoints { get; set; }
        public int ClanVersusPoints { get; set; }
        public int RequiredTrophies { get; set; }
        public string WarFrequency { get; set; }
        public int WarWinStreak { get; set; }
        public int WarWins { get; set; }
        public bool isWarLogPublic { get; set; }
        public int MemberCount { get; set; }
        public List<Models.ClanMember> Members { get; set; }

        // API Call: GET -- API Endpoint:  /clans/{clantag}
        public async Task GetClanInfoWithRest()
        {
            var clanTag = StaticVariables.ClanTag.Replace("#","%23");
            string _url = $"https://api.clashofclans.com/v1/clans/{clanTag}";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticVariables.Token);
                    HttpResponseMessage response = await client.GetAsync(_url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var clanInfo = JsonConvert.DeserializeObject<Clan>(responseBody);

                    Name = clanInfo.name;
                    Tag = clanInfo.tag;
                    ClanLevel = clanInfo.clanLevel;
                    Type = clanInfo.type;
                    Description = clanInfo.description;
                    ClanLevel = clanInfo.clanLevel;
                    ClanPoints = clanInfo.clanPoints;
                    ClanVersusPoints = clanInfo.clanVersusPoints;
                    RequiredTrophies = clanInfo.requiredTrophies;
                    WarFrequency = clanInfo.warFrequency;
                    WarWinStreak = clanInfo.warWinStreak;
                    WarWins = clanInfo.warWins;
                    isWarLogPublic = clanInfo.isWarLogPublic;
                    MemberCount = clanInfo.members;
                    Members = clanInfo.memberList;
              }
            }
            catch (Exception ex)  //TODO add the proper exception to this
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
