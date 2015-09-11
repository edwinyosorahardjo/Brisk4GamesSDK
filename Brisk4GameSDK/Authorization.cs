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
    /// <example>
    /// Credentials info = new Credentials()
    ///                    {
    ///                         Key = "username@b4gTenant.onmicrosoft.com",
    ///                         Secret = "Password"
    ///                     };
    /// </example>
    public class Credentials
    {
        /// <summary>
        /// The authentication key
        /// </summary>
        /// <returns>System.String</returns>
        public string Key { get; set; }

        /// <summary>
        /// The authentication secret
        /// </summary>
        /// <returns>System.String</returns>
        public string Secret { get; set; }
    }


    /// <summary>
    /// Holds the token associated with the successful authentication
    /// </summary>
    /// <example>
    /// Credentials info = new Credentials()
    ///                    {
    ///                         Key = "username@b4gTenant.onmicrosoft.com",
    ///                         Secret = "Password"
    ///                     };
    /// 
    /// AuthToken token = null;
    /// Authorization auth = new Authorization();
    /// 
    /// token = await auth.AuthenticateAsync(info);
    /// </example>
    public class AuthToken
    {
        /// <summary>
        /// The authorization token
        /// </summary>
        /// <returns><see cref="T:System.String"/></returns>
        public string Token { get; set; }
    }

    /// <summary>
    /// Supports Authoriziation for Brisk4Games
    /// </summary>
    /// <example>
    /// Credentials info = new Credentials()
    ///                    {
    ///                         Key = "username@b4gTenant.onmicrosoft.com",
    ///                         Secret = "Password"
    ///                     };
    /// 
    /// AuthToken token = null;
    /// Authorization auth = new Authorization();
    /// 
    /// token = await auth.AuthenticateAsync(info);
    /// </example>
    public class Authorization
    {
        private readonly string _tenantName = ConfigurationManager.AppSettings["TenantName"];
        private readonly string _clientId = ConfigurationManager.AppSettings["ClientId"];
        private readonly string _authority = ConfigurationManager.AppSettings["Authority"];
        private readonly string _appIdUri = ConfigurationManager.AppSettings["AppIdUri"];

        /// <summary>
        /// Authenticate using the given credentials
        /// </summary>
        /// <param name="credentials">The credentials used to authenticate </param>
        /// <returns>The authenticated <see cref="T:Task{Brisk4GameSDK.AuthToken}"/> token</returns>
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
