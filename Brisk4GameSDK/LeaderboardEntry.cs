using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brisk4GameSDK
{
    /// <summary>
    /// Represents a entry in a leaderboard
    /// </summary>
    /// <example>
    /// LeaderboardManager leaderboardManager = new LeaderboardManager(token);
    /// IEnumerable&gt;LeaderboardEntry%lt; global = await lmanager.GetGameLeaderboard("GameId");
    /// </example>
    public class LeaderboardEntry
    {
        /// <summary>
        /// The players Id
        /// </summary>
        /// <returns><see cref="System.String"/></returns>
        public string PlayerId { get; set; }
        /// <summary>
        /// The players score
        /// </summary>
        /// <returns><see cref="System.Int32"/></returns>
        public int Score { get; set; }
    }
}
