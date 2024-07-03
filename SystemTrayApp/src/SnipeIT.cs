using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DotNetEnv;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SnipeSharp;

namespace SystemTrayApp.src
{
    public class SnipeIT
    {        
        public static async Task CreateAsset(string asset_name, string serial_number, string mac, string uuid)
        {
            DotNetEnv.Env.Load(".env");

            string baseUrl = Global.ApiUrl;
            string apiToken = Global.ApiToken;
            string modelId = Global.ModelID;
            string statusId = Global.StatusID;

            try
            {
                var client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);

                if (mac.Contains('-')) mac = mac.Replace('-', ':');

                var asset = new
                {
                    name = asset_name,
                    model_id = modelId, 
                    serial = serial_number,
                    status_id = statusId,
                    _snipeit_mac_address_1 = mac,
                    _snipeit_uuid_2 = uuid,
                    category = 2
                };

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(asset);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(baseUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    Console.WriteLine("Asset created successfully. Response: " + responseBody);
                }
                else
                {
                    Console.WriteLine("Error: " + response.StatusCode);
                }
            }catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }
        public static async Task<bool> GetAssetByUuid(string uuid)
        {
            string baseUrl = Global.ApiUrl;
            string apiToken = Global.ApiToken;
            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);

            string url = $"{baseUrl}?search={uuid}";

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var jsonResponse = JObject.Parse(responseBody);

                    // Check if the payload contains any rows
                    var rows = jsonResponse["rows"];
                    if (rows != null && rows.HasValues)
                    {
                        Console.WriteLine("Asset retrieved successfully.\n");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Asset not found.\n");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}\n");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public static async Task<string> GetAssetProperties(string uuid, string key)
        {
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine($"Retrieving data for property: {key} of the asset with UUID:{uuid}");
            string baseUrl = Global.ApiUrl;
            string apiToken = Global.ApiToken;
            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);

            string url = $"{baseUrl}?search={uuid}";

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var jsonResponse = JObject.Parse(responseBody);

                    // Check if the payload contains any rows
                    var rows = jsonResponse["rows"];
                    if (rows != null && rows.HasValues)
                    {
                        Console.WriteLine("Asset retrieved successfully.\n");

                        // Retrieve the value from the JSON object where the key matches
                        foreach (var row in rows)
                        {
                            var value = row[key]?.ToString();
                            if (value != null)
                            {
                                Console.WriteLine($"Value: {value}");
                                return value;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Asset not found.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: " + response.StatusCode);
                }
            }catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.ToString());
                Console.ResetColor();
            }
            Console.WriteLine("--------------------------------------------------------------");
            return null;
        }
        public static async void CheckAsset()
        {
            bool assetExists = await Task.Run(() => SnipeIT.GetAssetByUuid(Global.Uuid));
            if (!assetExists) SnipeIT.CreateAsset(Global.HostName, Global.SerialNumber, "", Global.Uuid);
        }
        public static async Task<string> GetAssetNestedProperties(string uuid, string[] key)
        {
            Console.WriteLine("--------------------------------------------------------------");
            Console.Write($"Retrieving data for property: ");
            for(int i = 0; i < key.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{key[i]} ");
                Console.ResetColor();
            }
            Console.Write($"of the asset with UUID:{uuid}");
            string baseUrl = Global.ApiUrl;
            string apiToken = Global.ApiToken;
            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);

            string url = $"{baseUrl}?search={uuid}";

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var jsonResponse = JObject.Parse(responseBody);

                    var rows = jsonResponse["rows"];
                    foreach (var row in rows)
                    {
                        if (rows != null && rows.HasValues)
                        {
                            Console.WriteLine("Asset retrieved successfully.");

                            if (key.Length > 0)
                            {
                                switch (key.Length)
                                {
                                    case > 2:
                                        string value = row[key[0]][key[1]][key[2]]?.ToString();
                                        
                                        Console.Write($"Value: ");
                                        for (int i = 0; i < key.Length; i++)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.Write($"{key[i]} ");
                                            Console.ResetColor();
                                        }
                                        Console.WriteLine("\n");
                                        return value;

                                        break;
                                    default:
                                        string value1 = row[key[0]][key[1]]?.ToString();
                                      
                                        Console.Write($"Value: ");
                                        for (int i = 0; i < key.Length; i++)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.Write($"{key[i]} ");
                                            Console.ResetColor();
                                        }
                                        Console.WriteLine("\n");
                                        return value1;
                                        break;
                                }
                            }
                            else
                            {

                                Console.WriteLine("Asset not found.");
                                return null;
                            }

                        }
                        else
                        {
                            Console.WriteLine("Asset not found.");
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Error: " + response.StatusCode);
                }
            }catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(ex.Message);
                Console.ResetColor();
            }
            Console.WriteLine("--------------------------------------------------------------");
            return null;
        }
        public static async Task UpdateHardwareAssetProperty(string id, Dictionary<string, object> propertiesToUpdate)
        {
            string baseUrl = Global.ApiUrl; // Ensure this matches the base URL you used in Yaade
            string apiToken = Global.ApiToken; // Ensure this matches the token you used in Yaade

            try
            {
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine($"Attempting to update hardware asset with ID: {id}");
                Console.WriteLine($"API_URL: {baseUrl}/{id}");

                var client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);

                string url = $"{baseUrl}/{id}"; 

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(propertiesToUpdate);
                Console.WriteLine($"Request Body: {json}");

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync(url, content); 

                Console.WriteLine($"Response Status Code: {response.StatusCode}");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Hardware asset property updated successfully.");
                }
                else
                {
                    Console.WriteLine($"Error updating hardware asset. Status Code: {response.StatusCode}");
                    string responseBody = await response.Content.ReadAsStringAsync(); 

                    // Log response headers for additional debugging information
                    foreach (var header in response.Headers)
                    {
                        Console.WriteLine($"{header.Key}: {string.Join(", ", header.Value)}");
                    }
                    try
                    {
                        var errorResponse = JsonConvert.DeserializeObject<JObject>(responseBody);
                        Console.WriteLine($"Error Response: {errorResponse}");
                    }
                    catch (JsonReaderException)
                    {
                        Console.WriteLine($"Raw Error Response: {responseBody}");
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request failed: {ex.Message}");
            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine($"Request timed out or was canceled: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            Console.WriteLine("--------------------------------------------------------------");
        }
    }
}

