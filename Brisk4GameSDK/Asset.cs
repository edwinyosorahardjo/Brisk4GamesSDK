using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brisk4GameSDK
{

    /// <summary>
    /// Defines an Asset held in blob storage
    /// </summary>
    public class Asset
    {
        private string _filename;
        /// <summary>
        /// Gets the Filename
        /// </summary>
        /// <see cref="System.String"/>
        /// <returns>System.String</returns>
        public String Filename { get; }
        /// <summary>
        /// Gets a TenantName
        /// </summary>
        /// <returns>System.String</returns>
        public String TenantName { get; }
        /// <summary>
        /// The name of the Game
        /// </summary>
        /// <returns>System.String</returns>
        public String GameName { get; }
        /// <summary>
        /// The UserName associated with this Asset
        /// </summary>
        /// <returns>System.String</returns>
        public String UserName { get; }
        /// <summary>
        /// An endpoint location on the CDN for this asset
        /// </summary>
        /// <returns>System.String</returns>
        public String CdnEndpoint { get; }
        /// <summary>
        /// The Root Container
        /// </summary>
        /// <returns>System.String</returns>
        public String RootContainer { get;  }
    }
}
