using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Brisk4GameSDK
{
    /// <summary>
    /// Provides methods to manage Game Assets
    /// </summary>
    public class AssetManager : EndpointManager
    {

        public AssetManager(AuthToken token) : base(token, ConfigurationManager.AppSettings["AssetEndpoint"])
        {
            
        }

        /// <summary>
        /// Uploads a file to blob storage
        /// </summary>
        /// <param name="gameId">The game the asset should be associated with</param>
        /// <param name="localFilePath">The local system file path</param>
        /// <param name="mimeType">The file mime type</param>
        /// <returns></returns>
        public async Task<string> UploadFile(String gameId, string localFilePath, string mimeType)
        {
            return await _httpHelper.UploadFile(_token, $"api/{gameId}", localFilePath, mimeType);
        }

        /// <summary>
        /// Retrieves <see cref="Asset"/> associated with the authenticated user and the gameId
        /// </summary>
        /// <param name="gameId">The game the asset should be associated with</param>
        /// <see cref="Asset">See Asset</see>
        /// <returns>IEnumerable&lt;Asset&gt; list of assets in the appropriate blob storage file path</returns>
        public async Task<IEnumerable<Asset>> GetFiles(string gameId)
        {
            var response = await _httpHelper.Get(_token, $"api/{gameId}");
            return JsonConvert.DeserializeObject<IEnumerable<Asset>>(response);
        }

        /// <summary>
        /// Deletes an asset associated with the authenticated user 
        /// </summary>
        /// <param name="gameId">The game the asset should be associated with</param>
        /// <param name="filename">The name of the asset to delete</param>
        /// <returns></returns>
        public async Task<string> DeleteFile(string gameId, string filename)
        {
            return await _httpHelper.Delete(_token, $"api/{gameId}?filename={filename}");
        }

    }
}
