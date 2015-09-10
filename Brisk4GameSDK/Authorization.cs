using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Brisk4GameSDK
{
    /// <summary>
    /// Holds the credentials to use when authenticating
    /// </summary>
    public class Credentials
    {
        public string Key { get; set; }
        public string Secret { get; set; }
    }


    /// <summary>
    /// Holds the token associated with the successful authentication
    /// </summary>
    public class AuthToken
    {
        public string Token { get; set; }
    }

    /// <summary>
    /// Supports Authoriziation for Brisk4Games
    /// </summary>
    public class Authorization
    {
        private readonly string _tenantName = ConfigurationManager.AppSettings["TenantName"];
        private readonly string _clientId = ConfigurationManager.AppSettings["ClientId"];
        private readonly string _authority = ConfigurationManager.AppSettings["Authority"];
        private readonly string _appIdUri = ConfigurationManager.AppSettings["AppIdUri"];

        /// <summary>
        /// Authenticate using the given credentials
        /// </summary>
        /// <param name="credentials">The credentials to authenticate with</param>
        /// <returns>The authenticated token</returns>
        public async Task<AuthToken> AuthenticateAsync(Credentials credentials)
        {
            var context = new AuthenticationContext($"{_authority}/{_tenantName}");

            var userCred = new UserCredential(credentials.Key, credentials.Secret);

            AuthenticationResult result = await context.AcquireTokenAsync(_appIdUri, _clientId, userCred);

 
            return new AuthToken()
            {
                Token = result.AccessToken
            };
        }
    }
}
