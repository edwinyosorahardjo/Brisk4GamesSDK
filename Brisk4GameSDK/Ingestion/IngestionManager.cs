using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brisk4GameSDK.Ingestion
{
    internal class IngestionEndpoint
    {
        public string ConnectionString { get; set; }
        public string EventHubName { get; set; }
    }

    /// <summary>
    /// Manages the ingestion of messages (pastries?) 
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
    /// IngestionManager ingestionManager = new IngestionManager(token);
    /// ingestionManager.Send(new ScoreMessage("game1", "player666", 25));
    /// </example>
    public class IngestionManager
    {
        internal readonly HttpHelper _httpHelper;
        internal readonly AuthToken _token;
        private IngestionEndpoint _endpoint;
        private EventHubClient _eventHubClient;

        public IngestionManager(AuthToken token, String baseAddress)
        {
            _httpHelper = new HttpHelper(baseAddress);
            _token = token;
        }
        /// <summary>
        /// Sends the supplied message to Brisk4Games
        /// </summary>
        /// <param name="message">A populated game message</param>
        public async Task Send(IngestionMessage message)
        {
            if (!isInitialized())
                Initialize();
            
            _eventHubClient.Send(new EventData(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message))));
        }

        private void Initialize()
        {
            _endpoint =  JsonConvert.DeserializeObject<IngestionEndpoint>(
                _httpHelper.Get(_token, $"api/ingestion/endpoint").Result);
            _eventHubClient = EventHubClient.CreateFromConnectionString(_endpoint.ConnectionString, _endpoint.EventHubName);
        }

        private bool isInitialized()
        {
            return _endpoint != null;
        }
    }
}
