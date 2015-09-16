using System;
using System.Collections.Generic;

namespace Brisk4GameSDK.Ingestion
{
    /// <summary>
    /// Describes a message from a Game to the Brisk4Games system.
    /// </summary>
    public abstract class IngestionMessage
    {
        /// <summary>
        /// Constructs a new instance of this class; Properties is instantiated; all other properties are default(T)
        /// </summary>
        public IngestionMessage()
        {
            this.Properties = new Dictionary<string, string>();
        }

        /// <summary>
        /// The Time this event happened. This can be Client time or Game time; it's important that you choose a time scheme and keep consistently with it.
        /// </summary>
        /// <returns>System.DateTime</returns>
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// The IP of the consuming client
        /// </summary>
        /// <returns>System.String</returns>
        public string IPAddress { get; set; }
        /// <summary>
        /// The identifier of the Game
        /// </summary>
        /// <returns>System.String</returns>
        public string GameId { get; set; }
        /// <summary>
        /// The identifier of the Player
        /// </summary>
        /// <returns>System.String</returns>
        public string PlayerId { get; set; }
        /// <summary>
        /// The type of Message, i.e. "Score"/"Kill"/"Buy"/"Win"/"Lose"
        /// </summary>
        /// <returns>System.String</returns>
        public abstract string MessageType { get; }
        /// <summary>
        /// Custom properties for this message
        /// </summary>
        public IDictionary<string, string> Properties { get; set; }

        public static class CustomProperties
        {
            public const string MONETISATION_AMOUNT = "MonetisationAmount";
            public const string MONETISATION_CURRENCY = "MonetisationCurrency";
            public const string SCORE = "Score";
        }

    }
}