using Newtonsoft.Json;

namespace Integrador.Iugu.Response
{
    public class SimpleResponseMessage
    {
        /// <summary>
        /// Result of request
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}
