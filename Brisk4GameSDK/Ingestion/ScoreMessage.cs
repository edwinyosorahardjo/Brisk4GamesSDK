using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brisk4GameSDK.Ingestion
{
    /// <summary>
    /// A message describing a Score event in a game.
    /// </summary>
    /// <seealso cref="Brisk4GameSDK.Ingestion.IngestionMessage"/>
    public class ScoreMessage : IngestionMessage
    {
        /// <summary>
        /// Instantiates an instance of a Score message for a game and player.
        /// </summary>
        /// <param name="gameId">Scored Game</param>
        /// <param name="playerId">Scoring Player</param>
        /// <param name="score">Score Value</param>
        public ScoreMessage(string gameId, string playerId, int score)
        {
            this.GameId = gameId;
            this.PlayerId = playerId;
            this.Properties.Add(IngestionMessage.CustomProperties.SCORE, score.ToString());
        }

        /// <summary>
        /// The type of Message here is always "Score"
        /// </summary>
        /// <returns>System.String</returns>
        public override string MessageType
        {
            get
            {
                return IngestionMessage.CustomProperties.SCORE;
            }
        }
    }
}
