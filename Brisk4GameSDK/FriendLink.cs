using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brisk4GameSDK
{

    /// <summary>
    /// Encapsulates a relationship between two people and a game
    /// </summary>
    public class FriendLink
    {
        public String PlayerId { get; set; }
        public String FriendId { get; set; }
        public String GameId { get; set; }
    }
    
}
