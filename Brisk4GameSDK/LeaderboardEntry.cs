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
    /// IEnumerable<LeaderboardEntry> global = await lmanager.GetGameLeaderboard("GameId");
    /// </example>
    public class LeaderboardEntry
    {
        /// <summary>
        /// The players Id
        /// </summary>
        /// <returns><see cref="T:Task{System.String}"/></returns>
        public string PlayerId { get; set; }
        /// <summary>
        /// The players score
        /// </summary>
        /// <returns><see cref="T:Task{System.String}"/></returns>
        public int Score { get; set; }
    }
}
