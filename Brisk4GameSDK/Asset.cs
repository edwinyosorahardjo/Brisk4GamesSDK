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
        public String Filename { get { return _filename; } }
        public String TenantName { get; set; }
        public String GameName { get; set; }
        public String UserName { get; set; }
        public String CdnEndpoint { get; set; }
        public String RootContainer { get; set; }
    }
}
