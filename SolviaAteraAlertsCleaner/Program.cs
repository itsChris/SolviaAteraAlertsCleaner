using SolviaAteraAlertsCleaner;
using System.Net.Http.Headers;
using System.Text.Json;

class Program
{
    static async Task Main(string[] args)
    {
        // Try to get the API key from the environment variable
        string apiKey = Environment.GetEnvironmentVariable("AteraApiKey");

        // If the API key is not set, prompt the user to provide it
        if (string.IsNullOrEmpty(apiKey))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: The API Key environment variable 'AteraApiKey' is not set.");
            Console.ResetColor();
            Console.Write("Please enter your API Key: ");
            apiKey = Console.ReadLine();
        }

        // Define the initial API URL for getting alerts
        string apiUrl = "https://app.atera.com/api/v3/alerts";
        string apiUrlDelete = "https://app.atera.com/api/v3/alerts/";

        // Create an HttpClient instance
        using (HttpClient client = new HttpClient())
        {
            // Set the Accept header for JSON
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Set the API key in the header
            client.DefaultRequestHeaders.Add("X-API-KEY", apiKey);

            bool moreAlerts = true;

            while (moreAlerts)
            {
                try
                {
                    // Send a GET request to the API
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    // Ensure the request was successful
                    response.EnsureSuccessStatusCode();

                    // Read the response content as a string
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                        WriteIndented = true // Optional, for pretty printing
                    };
                    AlertsResponse alertsResponse = JsonSerializer.Deserialize<AlertsResponse>(responseBody, options);

                    // Output the deserialized response
                    Console.WriteLine("Deserialized API Response:");
                    Console.WriteLine($"Page: {alertsResponse.Page}");
                    Console.WriteLine($"Items in Page: {alertsResponse.ItemsInPage}");
                    Console.WriteLine($"Total Pages: {alertsResponse.TotalPages}");
                    Console.WriteLine($"Total Item Count: {alertsResponse.TotalItemCount}");
                    Console.WriteLine($"Next Link: {alertsResponse.NextLink}");
                    Console.WriteLine($"Alerts on this Page: {alertsResponse.Items.Count}");

                    // Output and process each alert
                    foreach (var alert in alertsResponse.Items)
                    {
                        Console.WriteLine($"Alert ID: {alert.AlertID}, " +
                                          $"Code: {alert.Code}, " +
                                          $"Source: {alert.Source}, " +
                                          $"Title: {alert.Title}, " +
                                          $"Severity: {alert.Severity}, " +
                                          $"Created: {alert.Created}, " +
                                          $"Snoozed End Date: {(alert.SnoozedEndDate.HasValue ? alert.SnoozedEndDate.ToString() : "N/A")}, " +
                                          $"Device Guid: {alert.DeviceGuid}, " +
                                          $"Additional Info: {alert.AdditionalInfo ?? "N/A"}, " +
                                          $"Archived: {alert.Archived}, " +
                                          $"Alert Category ID: {alert.AlertCategoryID}, " +
                                          $"Archived Date: {(alert.ArchivedDate.HasValue ? alert.ArchivedDate.ToString() : "N/A")}, " +
                                          $"Ticket ID: {(alert.TicketID.HasValue ? alert.TicketID.ToString() : "N/A")}, " +
                                          $"Alert Message: {alert.AlertMessage}, " +
                                          $"Device Name: {alert.DeviceName}, " +
                                          $"Customer ID: {alert.CustomerID}, " +
                                          $"Customer Name: {alert.CustomerName}, " +
                                          $"Folder ID: {(alert.FolderID.HasValue ? alert.FolderID.ToString() : "N/A")}, " +
                                          $"Polling Cycles Count: {(alert.PollingCyclesCount.HasValue ? alert.PollingCyclesCount.ToString() : "N/A")}");

                        // Check if the CustomerID is 8
                        if (alert.CustomerID == 3 && alert.Title.ToLower().StartsWith("failed login attempts") && alert.DeviceName.ToLower().StartsWith("refpc"))
                        {
                            // Delete the alert
                            string deleteUrl = $"{apiUrlDelete}/{alert.AlertID}";
                            HttpResponseMessage deleteResponse = await client.DeleteAsync(deleteUrl);

                            if (deleteResponse.IsSuccessStatusCode)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"Successfully deleted alert with ID: {alert.AlertID}");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Failed to delete alert with ID: {alert.AlertID}. Status Code: {deleteResponse.StatusCode}");
                                Console.ResetColor();
                            }
                        }
                    }

                    // Check if there is a next page
                    if (!string.IsNullOrEmpty(alertsResponse.NextLink))
                    {
                        apiUrl = alertsResponse.NextLink;
                    }
                    else
                    {
                        moreAlerts = false;
                    }
                }
                catch (HttpRequestException e)
                {
                    // Handle any errors
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message: {0} ", e.Message);
                    moreAlerts = false;
                }
            }
        }
    }
}
