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
        public String Filename { get; }
        public String TenantName { get; }
        public String GameName { get; }
        public String UserName { get; }
        public String CdnEndpoint { get; }
        public String RootContainer { get;  }
    }
}
