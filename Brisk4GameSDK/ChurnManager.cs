using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brisk4GameSDK
{
    /// <summary>
    /// Retrieves user churn values
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
    /// ChurnManager churnManager = new ChurnManager(token);
    /// </example>
    public class ChurnManager : EndpointManager
    {
        /// <summary>
        /// Constructor method accepting a valid authentication token
        /// </summary>
        /// <param name="token">A valid authentication token</param>
        public ChurnManager(AuthToken token) : base(token, ConfigurationManager.AppSettings["FabricEndpoint"])
        {
        }

        /// <summary>
        /// Returns the churn value for the given game and player id
        /// </summary>
        /// <param name="gameId">The game for which the churn value should be retrieved</param>
        /// <param name="playerId">The player for which the churn value should be retrieved</param>
        /// <returns>The churn value as a <see cref="T:Task{System.String}"/></returns>
        public async Task<string> Get(string gameId, string playerId)
        {
            return await _httpHelper.Get(_token, $"api/churn/{gameId}/{playerId}");
        }
    }
}
