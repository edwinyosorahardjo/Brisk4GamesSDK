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
        public String Filename { get; }
        /// <summary>
        /// Gets a TenantName
        /// </summary>
        public String TenantName { get; }
        /// <summary>
        /// The name of the Game
        /// </summary>
        public String GameName { get; }
        /// <summary>
        /// The UserName associated with this Asset
        /// </summary>
        public String UserName { get; }
        /// <summary>
        /// An endpoint location on the CDN for this asset
        /// </summary>
        public String CdnEndpoint { get; }
        /// <summary>
        /// The Root Container
        /// </summary>
        public String RootContainer { get;  }
    }
}
