using System.Text.Json.Serialization;

namespace SolviaAteraAlertsCleaner
{
    public class AlertsResponse
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("itemsInPage")]
        public int ItemsInPage { get; set; }

        [JsonPropertyName("totalPages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("prevLink")]
        public string PrevLink { get; set; }

        [JsonPropertyName("nextLink")]
        public string NextLink { get; set; }

        [JsonPropertyName("items")]
        public List<Alert> Items { get; set; }

        [JsonPropertyName("totalItemCount")]
        public int TotalItemCount { get; set; }
    }
}
