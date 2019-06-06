using StatTrackers.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StatTrackers.Controllers;
using System.Net.Http.Headers;
using StatTrackers.Member;
using System.Threading;
using static StatTrackers.StaticVariables;

namespace StatTrackers
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var clanInfo = new ClanInfo();
            await clanInfo.GetClanInfoWithRest();

            Console.WriteLine($"ClanInfo -- {DateTime.Now}\nClanName: {clanInfo.Name}\nClanTag: {clanInfo.Tag}\nClanLevel: {clanInfo.ClanLevel}" +
                $"\nMember Count: {clanInfo.MemberCount}");
            Console.WriteLine("----------------------------------");

            var playerInfo = new PlayerInfo();
            playerInfo.PrintPlayers(StaticVariables.ClanTag);

            Console.ReadKey();
        }
    } 
}
