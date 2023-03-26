

using Newtonsoft.Json;

namespace Data.Dto.Yandex
{
    public class YandexAuthResponseDto
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("expire_in")]
        public DateTime ExpireDate { get; set; }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
        
    }
}
