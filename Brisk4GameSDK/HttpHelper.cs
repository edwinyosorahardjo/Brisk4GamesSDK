using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Brisk4GameSDK
{
    internal class HttpHelper
    {
        private readonly string _baseAddress; 

        internal HttpHelper(string baseAddress)
        {
            _baseAddress = baseAddress;
        }

        /// <summary>
        /// Helper method to invoke an endpoint using GET
        /// </summary>
        /// <param name="token">The authentication token</param>
        /// <param name="path">The endpoint to invoke</param>
        /// <returns>The result of the operation</returns>
        internal async Task<String> Get(AuthToken token, string path)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                HttpRequestMessage message = new HttpRequestMessage();
                message.Method = HttpMethod.Get;
                message.RequestUri = new Uri($"{_baseAddress}/{path}");
                message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);

                HttpResponseMessage response = await client.SendAsync(message);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();

                }
                else
                {
                    throw new ApplicationException($"{response.StatusCode} {response.ReasonPhrase}");
                }

            }
        }

        /// <summary>
        /// Uploads a file to the specified endpoint
        /// </summary>
        /// <param name="token">The authentication token</param>
        /// <param name="path">The endpoint to invoke</param>
        /// <param name="filename">The local file system path to the file</param>
        /// <param name="contentType">The mime-type</param>
        /// <returns>The result of the operation</returns>
        internal async Task<string> UploadFile(AuthToken token, string path, string filename, string contentType)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage message = new HttpRequestMessage();
                message.Method = HttpMethod.Post;
                message.RequestUri = new Uri($"{_baseAddress}/{path}");
                message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
                

                var content =
                    new MultipartFormDataContent("Upload----" + DateTime.Now.ToString(CultureInfo.InvariantCulture));
          

                var streamContent = new StreamContent(File.OpenRead(filename));
                streamContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                content.Add(streamContent, Path.GetFileName(filename), Path.GetFileName(filename));
                message.Content = content;

                var response =
                    await client.SendAsync(message);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();

                }
                else
                {
                    throw new ApplicationException($"{response.StatusCode} {response.ReasonPhrase}");
                }
            }

        }


        /// <summary>
        /// Helper method to invoke an endpoint using POST
        /// </summary>
        /// <param name="token">The authenticationt token</param>
        /// <param name="path">The endpoint to invoke</param>
        /// <returns>The result of the operation</returns>
        internal async Task<string> Post(AuthToken token, string path)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                HttpRequestMessage message = new HttpRequestMessage();
                message.Method = HttpMethod.Post;
                message.RequestUri = new Uri($"{_baseAddress}/{path}");
                message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);

                HttpResponseMessage response = await client.SendAsync(message);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();

                }
                else
                {
                    throw new ApplicationException($"{response.StatusCode} {response.ReasonPhrase}");
                }
            }
        }

        /// <summary>
        /// Helper method to invoke an endpoint using POST
        /// </summary>
        /// <param name="token">The authenticationt token</param>
        /// <param name="path">The endpoint to invoke</param>
        /// <param name="body">The message body</param>
        /// <returns>The result of the operation</returns>
        internal async Task<string> Post(AuthToken token, string path, string body)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                HttpRequestMessage message = new HttpRequestMessage();
                message.Method = HttpMethod.Post;
                message.Content = new StringContent(body, Encoding.UTF8, "application/json");
                message.RequestUri = new Uri($"{_baseAddress}/{path}");
                message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);

                HttpResponseMessage response = await client.SendAsync(message);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();

                }
                else
                {
                    throw new ApplicationException($"{response.StatusCode} {response.ReasonPhrase}");
                }
            }
        }

        /// <summary>
        /// Helper method to invoke an endpoint using DELETE
        /// </summary>
        /// <param name="token">The authenticationt token</param>
        /// <param name="path">The endpoint to invoke</param>
        /// <returns>The result of the operation</returns>
        internal async Task<String> Delete(AuthToken token, string path)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                HttpRequestMessage message = new HttpRequestMessage();
                message.Method = HttpMethod.Delete;
                message.RequestUri = new Uri($"{_baseAddress}/{path}");
                message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);

                HttpResponseMessage response = await client.SendAsync(message);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();

                }
                else
                {
                    throw new ApplicationException($"{response.StatusCode} {response.ReasonPhrase}");
                }

            }
        }
    }
}
 
