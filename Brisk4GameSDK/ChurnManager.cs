using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brisk4GameSDK
{
    public class ChurnManager : EndpointManager
    {
        public ChurnManager(AuthToken token) : base(token, ConfigurationManager.AppSettings["FabricEndpoint"])
        {
        }

        /// <summary>
        /// Returns the churn value for the given game and player id
        /// </summary>
        /// <param name="gameId">The game for which the churn value should be retrieved</param>
        /// <param name="playerId">The player for which the churn value should be retrieved</param>
        /// <returns>The churn value</returns>
        public async Task<string> Get(string gameId, string playerId)
        {
            return await _httpHelper.Get(_token, $"api/churn/{gameId}/{playerId}");
        }
    }
}
