using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brisk4GameSDK
{
    public class EndpointManager
    {
        internal readonly HttpHelper _httpHelper;
        internal readonly AuthToken _token;

        public EndpointManager(AuthToken token, String baseAddress)
        {
            _httpHelper = new HttpHelper(baseAddress);
            _token = token;
        }
    }
}
