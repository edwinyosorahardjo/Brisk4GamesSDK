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
    public class LeaderboardEntry
    {
        public string PlayerId { get; set; }
        public int Score { get; set; }
    }
}
