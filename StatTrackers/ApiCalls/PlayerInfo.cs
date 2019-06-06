using Newtonsoft.Json;
using StatTrackers.Member;
using StatTrackers.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using static StatTrackers.StaticVariables;

namespace StatTrackers.Controllers
{
    public class PlayerInfo
    {
        // Will this work without being async?
        //OK it works but this has to be inefficient but i dont know why
        public List<Player> GetListOfPlayersFromClan(string clanTag) {
            List<Player> playerList = new List<Player> { };
            var clanInfo = new Controllers.ClanInfo();
            clanInfo.GetClanInfoWithRest().GetAwaiter().GetResult();
            var count = 1;
            foreach (ClanMember clanMember in clanInfo.Members)
            {
                var encodedWarTag = clanMember.tag.Replace("#", "%23");
                var url = $"https://api.clashofclans.com/v1/players/{encodedWarTag}";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", StaticVariables.Token);
                HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();
                string responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                var playerInfo = JsonConvert.DeserializeObject<Player>(responseBody);
                playerList.Add(playerInfo);
                //Thread.Sleep(120);
                Console.WriteLine($"{count++}. {playerInfo.name}\t\t{playerInfo.warStars}");
            }
            return playerList;
        }

        // Prints list of players if given the list
        public void PrintPlayers(List<Player> players)  
        {
            int count = 0;
            int sum = 1;
            Console.WriteLine("     PlayerName\tWarstars");
            foreach (Player player in players)
            {
                Console.WriteLine($"{count++}. {player.name}\t{player.warStars}");
                sum += player.warStars;
            }
            Console.WriteLine($"Average war stars: {sum / count}\n");
            Console.WriteLine($"Total War Stars: {sum}\n" +
                $"Total Players: {count}\n" +
                $"Total Players in clan: {players.Count}\n");
        }

        //prints list of players if given clantag
        public void PrintPlayers(string clanTag)
        {
            var players = GetListOfPlayersFromClan(clanTag);
            int count = 0;
            int sum = 1;
            Console.WriteLine("     PlayerName\tWarstars");
            foreach (Player player in players)
            {
                Console.WriteLine($"{count++}. {player.name}\t{player.warStars}");
                sum += player.warStars;
            }
            Console.WriteLine($"Average war stars: {sum / count}\n");
            Console.WriteLine($"Total War Stars: {sum}\n" +
                $"Total Players: {count}\n" +
                $"Total Players in clan: {players.Count}\n");
        }


    }
}
