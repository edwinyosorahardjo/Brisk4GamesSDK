using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Brisk4GameSDK;
using Newtonsoft.Json;

namespace ConsoleAppTester
{

    class Program
    {
        
        static void Main(string[] args)
        {

            Credentials info = new Credentials()
            {
                Key = "david@b4gTenant.onmicrosoft.com",
                Secret = "_ML{{;f$LS"
            };
            AuthToken token = null;
            Authorization auth = new Authorization();
            Task.Run(async () =>
            {
                token = await auth.AuthenticateAsync(info);
                    
                /*AssetManager assetManager = new AssetManager(token);
                var uploadResponse = await assetManager.UploadFile("AS3", @"c:\tmp\data2.csv", "application/vnd.ms-excel");

                Console.WriteLine(uploadResponse);

                var listResponse = await assetManager.GetFiles("AS3");
                Console.WriteLine(JsonConvert.SerializeObject(listResponse));

                var deleteResponse = await assetManager.DeleteFile("AS3", "data2.csv");
                Console.WriteLine(deleteResponse);*/

                FriendManager manager = new FriendManager(token);

                var addResult = await manager.AddFriend(
                    new FriendLink()
                    {
                        GameId = "AS3",
                        PlayerId = "player1",
                        FriendId = "player3"
                    });

                Console.WriteLine(addResult);

                var addFriendsResult = await manager.AddFriends(new List<FriendLink>()
                {
                    new FriendLink()
                    {
                        GameId = "AS3",
                        PlayerId = "player1",
                        FriendId = "player4"
                    },

                    new FriendLink()
                    {
                        GameId = "AS3",
                        PlayerId = "player1",
                        FriendId = "player5"
                    },
                });

                Console.WriteLine(addFriendsResult);

                var friends = await manager.GetFriends("AS3", "player1");
                Console.WriteLine(friends);

                var deleteResult = await manager.DeleteFriend(new FriendLink()
                {
                    GameId = "AS3",
                    PlayerId = "player1",
                    FriendId = "player3"
                });

                Console.WriteLine(deleteResult);

                LeaderboardManager lmanager = new LeaderboardManager(token);

                var global = await lmanager.GetGameLeaderboard("AS3");
                Console.WriteLine(global);

                var friend = await lmanager.GetFriendLeaderboard("AS3", "player1");
                Console.WriteLine(friend);

                var country = await lmanager.GetCountryLeaderboard("AS3", "UK");
                Console.WriteLine(country);

                ChurnManager churnManager = new ChurnManager(token);

                var churn = await churnManager.Get("AS3", "player1");
                Console.WriteLine(churn);
                
            }).Wait();




}
}
}
