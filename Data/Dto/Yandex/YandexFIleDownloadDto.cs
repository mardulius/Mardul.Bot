using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dto.Yandex
{
    public class YandexFIleDownloadDto
    {
        [JsonProperty("operation_id")]
        public string OperationId { get; set; }

        [JsonProperty("href")]
        public Uri Href { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("templated")]
        public bool Templated { get; set; }
    }
}
