using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace CodingChallenge
{
    /// <summary>
    ///     Sends requests to the SWAPI.
    /// </summary>
    public static class SwapiOperations
    {
        /// <summary>
        ///     Gets an object of the specified type from the URL.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="url">URL of the resource.</param>
        /// <returns>A T.</returns>
        public static T Get<T>(string url) where T : class
        {
            string result = string.Empty;
            var uri = new Uri(url);
            using (var client = new HttpClient())
            {
                client.GetStringAsync(uri).ContinueWith(c =>
                {
                    result = c.Result;
                    return result;
                }).Wait();
            }
            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}