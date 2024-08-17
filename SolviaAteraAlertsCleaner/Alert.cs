using System.Text.Json.Serialization;
namespace SolviaAteraAlertsCleaner
{
    public class Alert
    {
        [JsonPropertyName("AlertID")]
        public int AlertID { get; set; }

        [JsonPropertyName("Code")]
        public long Code { get; set; }

        [JsonPropertyName("Source")]
        public string Source { get; set; }

        [JsonPropertyName("Title")]
        public string Title { get; set; }

        [JsonPropertyName("Severity")]
        public string Severity { get; set; }

        [JsonPropertyName("Created")]
        public DateTime Created { get; set; }

        [JsonPropertyName("SnoozedEndDate")]
        public DateTime? SnoozedEndDate { get; set; }

        [JsonPropertyName("DeviceGuid")]
        public string DeviceGuid { get; set; }

        [JsonPropertyName("AdditionalInfo")]
        public string AdditionalInfo { get; set; }

        [JsonPropertyName("Archived")]
        public bool Archived { get; set; }

        [JsonPropertyName("AlertCategoryID")]
        public string AlertCategoryID { get; set; }

        [JsonPropertyName("ArchivedDate")]
        public DateTime? ArchivedDate { get; set; }

        [JsonPropertyName("TicketID")]
        public int? TicketID { get; set; }

        [JsonPropertyName("AlertMessage")]
        public string AlertMessage { get; set; }

        [JsonPropertyName("DeviceName")]
        public string DeviceName { get; set; }

        [JsonPropertyName("CustomerID")]
        public int CustomerID { get; set; }

        [JsonPropertyName("CustomerName")]
        public string CustomerName { get; set; }

        [JsonPropertyName("FolderID")]
        public int? FolderID { get; set; }

        [JsonPropertyName("PollingCyclesCount")]
        public int? PollingCyclesCount { get; set; }
    }
}