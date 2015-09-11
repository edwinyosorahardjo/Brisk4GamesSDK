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
    /// <example>
    ///  var friend = new FriendLink()
    ///               {
    ///                    GameId = "GameId",
    ///                    PlayerId = "PlayerId",
    ///                    FriendId = "FriendId"
    ///               }
    /// </example>
public class FriendLink
    {
        /// <summary>
        /// The Id of the Player
        /// </summary>
        /// <returns>System.String</returns>
        public String PlayerId { get; set; }
        /// <summary>
        /// The Id of the Friend
        /// </summary>
        /// <returns>System.String</returns>
        public String FriendId { get; set; }
        /// <summary>
        /// The Id of the Game
        /// </summary>
        /// <returns>System.String</returns>
        public String GameId { get; set; }
    }
    
}
