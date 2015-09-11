using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Brisk4GameSDK
{
    /// <summary>
    /// Manages Friend Relationships
    /// </summary>
    public class FriendManager : EndpointManager
    {
        public FriendManager(AuthToken token) : base(token, ConfigurationManager.AppSettings["FabricEndpoint"])
        {
        }
       
        /// <summary>
        /// Create a new friend relationship between two people
        /// </summary>
        /// <param name="friend">Defines the relationship between 2 people and a game</param>
        /// <returns>The result of the operation</returns>
        public async Task<string> AddFriend(FriendLink friend)
        {
            return await _httpHelper.Post(_token, $"api/friend/{friend.GameId}/{friend.PlayerId}/{friend.FriendId}");
        }

       
        /// <summary>
        /// Creates new friend relationships between a list of people 
        /// All elements relate to the same player and game
        /// </summary>
        /// <param name="friends">A list of friends relationships</param>
        /// <returns>The result of the operation</returns>
        public async Task<string> AddFriends(IEnumerable<FriendLink> friends)
        {
            var friendList = friends.Select(fl => fl.FriendId).ToList();
            var gameId = friends.First().GameId;
            var playerId = friends.First().PlayerId;
            return await _httpHelper.Post(_token, $"api/friend/{gameId}/{playerId}/batch", JsonConvert.SerializeObject(friendList)); ;
        }

        /// <summary>
        /// Retrieves friends assoicated with the player and game
        /// </summary>
        /// <param name="gameId">The game associated with the player</param>
        /// <param name="playerId">The player whose friends should be retrieved</param>
        /// <returns>A list of friends associated with the game and player <see cref="List{String}"/></returns>
        public async Task<IEnumerable<string>> GetFriends(string gameId, string playerId)
        {
            var result = await _httpHelper.Get(_token, $"api/friend/{gameId}/{playerId}");

            return JsonConvert.DeserializeObject<IEnumerable<string>>(result);
        }

        /// <summary>
        /// Removes a friend relationship
        /// </summary>
        /// <param name="friend">The friend relationship that should be deleted</param>
        /// <returns>The result of the operation</returns>
        public async Task<string> DeleteFriend(FriendLink friend)
        {
            return await _httpHelper.Delete(_token, $"api/friend/{friend.GameId}/{friend.PlayerId}/{friend.FriendId}");
        }

    }
}
