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
    /// Provides access to player leaderboards
    /// </summary>
    /// <example>
    /// Credentials info = new Credentials()
    ///                    {
    ///                         Key = "username@b4gTenant.onmicrosoft.com",
    ///                         Secret = "Password"
    ///                     };
    /// 
    /// AuthToken token = null;
    /// Authorization auth = new Authorization();
    /// 
    /// token = await auth.AuthenticateAsync(info);
    /// LeaderboardManager leaderboardManager = new LeaderboardManager(token);
    /// </example>
    public class LeaderboardManager :EndpointManager
    {
        /// <summary>
        /// Constructor method accepting a valid authentication token
        /// </summary>
        /// <param name="token">A valid authentication token</param>
        public LeaderboardManager(AuthToken token) : base(token, ConfigurationManager.AppSettings["FabricEndpoint"])
        {
        }

        /// <summary>
        /// Returns a leaderboard for a given game Id
        /// </summary>
        /// <param name="gameId">The game the leaderboard is associated with</param>
        /// <returns>The retrieved leaderboard as <see cref="T:Task{IEnumerable{Brisk4GameSDK.LeaderboardEntry}}"/></returns>
        public async Task<IEnumerable<LeaderboardEntry>> GetGameLeaderboard(string gameId)
        {
            var response = await _httpHelper.Get(_token, $"api/leaderboard/{gameId}");
            return JsonConvert.DeserializeObject<IEnumerable<LeaderboardEntry>>(response);
        }

        /// <summary>
        /// Returns a friend leaderboard for a given game Id
        /// </summary>
        /// <param name="gameId">The game the leaderboard is associated with</param>
        /// <param name="playerId">The player the leaderboard is associated with</param>
        /// <returns>The retrieved leaderboard as <see cref="T:Task{IEnumerable<LeaderboardEntry>}"/></returns>
        public async Task<IEnumerable<LeaderboardEntry>> GetFriendLeaderboard(string gameId, string playerId)
        {
            var response = await _httpHelper.Get(_token, $"api/leaderboard/{gameId}/{playerId}");
            return JsonConvert.DeserializeObject<IEnumerable<LeaderboardEntry>>(response);
        }


        /// <summary>
        /// Returns a country leaderboard for a given game Id
        /// </summary>
        /// <param name="gameId">The game the leaderboard is associated with</param>
        /// <param name="countryId">The country code the leaderboard is associated with</param>
        /// <returns>The retrieved leaderboard as <see cref="T:Task{IEnumerable<LeaderboardEntry>}"/></returns>
        public async Task<IEnumerable<LeaderboardEntry>> GetCountryLeaderboard(string gameId, string countryId)
        {
            var response = await _httpHelper.Get(_token, $"api/leaderboard/{gameId}/{countryId}");
            return JsonConvert.DeserializeObject<IEnumerable<LeaderboardEntry>>(response);
        }
    }
}
