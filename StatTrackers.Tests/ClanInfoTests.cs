using System;
using Xunit;
using StatTrackers;
using StatTrackers.Controllers;

namespace StatTrackers.Tests
{
    public class ClanInfoTests
    {
        [Fact]
        public async void NameTagClanLevelAreCorrect()
        {
            var testClanInfo = new ClanInfo();
            await testClanInfo.GetClanInfoWithRest();
            Assert.Equal("Nuke", testClanInfo.Name);
            Assert.Equal("#GC9L8QR", testClanInfo.Tag);
            Assert.Equal(12, testClanInfo.ClanLevel);

        }
    }
}
