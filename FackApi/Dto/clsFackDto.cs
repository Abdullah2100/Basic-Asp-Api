using System.Text.Json.Serialization;

namespace FackApi.Dto
{
    public class clsFackDto
    {
        [JsonPropertyName("id")]
        public int? id { get; set; } = null;

        [JsonPropertyName("name")]
        public string name { get; set; } = "";

        [JsonPropertyName("job")]
        public string job { get; set; } = "";

        [JsonPropertyName("isDeleted")]
        public bool? isDeleted { get; set; } = false;

        public bool isHasNullValue
        {
            get { return string.IsNullOrEmpty(name) || string.IsNullOrEmpty(job); }
        }
    }
}
