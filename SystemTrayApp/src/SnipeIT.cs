using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNetEnv;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SnipeSharp;
using RestSharp;
using System.Net.NetworkInformation;

namespace SystemTrayApp.src
{
    public class SnipeIT
    {
        public static async Task CreateAsset(string asset_name, string serial_number, string mac, string uuid)
        {
            DotNetEnv.Env.Load($@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\SnipeAgent\.Env");
            string macCustomField = DotNetEnv.Env.GetString("MAC_CUSTOM_FIELD");
            string uuidCustomField = DotNetEnv.Env.GetString("UUID_CUSTOM_FIELD");
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

                // Initialize the asset as a Dictionary to allow dynamic property names
                var asset = new Dictionary<string, object>
                {
                    ["name"] = asset_name,
                    ["model_id"] = modelId,
                    ["serial"] = serial_number,
                    ["status_id"] = statusId,
                    ["category"] = 2 // Assuming 'category' is a fixed property, adjust as necessary
                };

                // Dynamically add the custom fields using the environment variable names
                asset[macCustomField] = mac;
                asset[uuidCustomField] = uuid;

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(asset);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync($"{baseUrl}/hardware", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    Console.WriteLine("Asset created successfully. Response: " + responseBody);
                }
                else
                {
                    Console.WriteLine("Error: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }

        public static async Task<bool> CheckIfModelExists()
        {
            string modelNumber = Global.SystemModel;
            string baseUrl = Global.ApiUrl;
            string apiToken = Global.ApiToken;
            string models_url = $"{baseUrl}/models";

            try
            {
                using var client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);

                HttpResponseMessage response = await client.GetAsync(models_url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var models = JsonConvert.DeserializeObject<dynamic>(jsonString);

                    foreach (var row in models.rows)
                    {
                        // Check if row is not null before accessing its properties
                        if (row != null)
                        {
                            Console.WriteLine($"Model from JSON: {row.model_number?.ToString()}"); // Use null-conditional operator to safely access ToString
                            Console.WriteLine($"Model from local machine: {modelNumber}");

                            // Trim both strings to ensure no leading/trailing whitespaces affect the comparison
                            if (row.model_number == modelNumber.Trim())
                            {
                                Console.WriteLine("returning true");
                                return true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Row is null.");
                        }
                    }
                }
                Console.WriteLine("returning false");
                return false;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return false;
            }
        }
        public static async Task<int> GetSystemModelID()
        {
            string modelNumber = Global.SystemModel;
            string baseUrl = Global.ApiUrl;
            string apiToken = Global.ApiToken;
            string models_url = $"{baseUrl}/models";

            try
            {
                using var client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);

                HttpResponseMessage response = await client.GetAsync(models_url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var models = JsonConvert.DeserializeObject<dynamic>(jsonString);

                    foreach (var row in models.rows)
                    {
                        // Check if row is not null before accessing its properties
                        if (row != null)
                        {
                            Console.WriteLine($"Model from JSON: {row.model_number?.ToString()}"); // Use null-conditional operator to safely access ToString
                            Console.WriteLine($"Model from local machine: {modelNumber}");

                            // Trim both strings to ensure no leading/trailing whitespaces affect the comparison
                            if (row.model_number == modelNumber.Trim())
                            {
                                return (int)row.id;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Row is null.");
                        }
                    }
                }
                Console.WriteLine("returning false");
                return int.Parse(Global.ModelID);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return int.Parse(Global.ModelID);
            }
        }
        public static async Task<string> GetCategory(string modelNumber)
        {
            string baseUrl = Global.ApiUrl;
            string apiToken = Global.ApiToken;
            string models_url = $"{baseUrl}/models";

            try
            {
                using var client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);

                HttpResponseMessage response = await client.GetAsync(models_url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var models = JsonConvert.DeserializeObject<dynamic>(jsonString); 

                    foreach (var row in models.rows)
                    {
                        if (row.model_number == modelNumber)
                        {
                            return row.category.id.ToString();
                        }
                    }
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return string.Empty;
            }
        }
        public static async Task CreateAssetWithModel(string asset_name, int model_id, string serial_number, string mac, string uuid, string category)
        {
            DotNetEnv.Env.Load($@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\SnipeAgent\.Env");
            string macCustomField = DotNetEnv.Env.GetString("MAC_CUSTOM_FIELD");
            string uuidCustomField = DotNetEnv.Env.GetString("UUID_CUSTOM_FIELD");
            string apiToken = Global.ApiToken;
            string statusId = Global.StatusID;

            try
            {
                var client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);

                if (mac.Contains('-')) mac = mac.Replace('-', ':');

                // Initialize the asset as a Dictionary to allow dynamic property names
                var asset = new Dictionary<string, object>
                {
                    ["name"] = asset_name,
                    ["model_id"] = model_id,
                    ["serial"] = serial_number,
                    ["status_id"] = statusId,
                    ["category"] = category
                };

                // Dynamically add the custom fields using the environment variable names
                asset[macCustomField] = mac;
                asset[uuidCustomField] = uuid;

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(asset);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(Global.ApiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    Console.WriteLine("Asset created successfully. Response: " + responseBody);
                }
                else
                {
                    Console.WriteLine("Error: " + response.StatusCode);
                }
            }
            catch (Exception ex)
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

            string url = $"{baseUrl}/hardware?search={uuid}";

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

            string url = $"{baseUrl}/hardware?search={uuid}";

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
            if (!assetExists)
            {
                bool model_exists = await SnipeIT.CheckIfModelExists();
                
                string category = await SnipeIT.GetCategory(Global.SystemModel);
                int model_id = await SnipeIT.GetSystemModelID();
                if (model_exists)
                {
                    SnipeIT.CreateAssetWithModel(Global.HostName, model_id, Global.SerialNumber, getMacAddress(0), Global.Uuid, category);
                } else
                {
                    SnipeIT.CreateAsset(Global.HostName, Global.SerialNumber, getMacAddress(0), Global.Uuid);
                }
            }
            
        }
        //TODO: Retrieval fails if the model ID has changed
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

            string url = $"{baseUrl}/hardware?search={uuid}";

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
                var client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);

                string url = $"{baseUrl}/hardware/{id}";

                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine($"Attempting to update hardware asset with ID: {id}");
                Console.WriteLine($"API_URL: {url}");

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(propertiesToUpdate);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"Request Body: {json}");
                Console.ResetColor();

                HttpResponseMessage response = await client.PutAsync(url, content);

                if (response.IsSuccessStatusCode)
                {

                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"Response Status Code: {response.StatusCode}");
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Hardware asset property updated successfully.");
                }
                else
                {

                    Console.BackgroundColor = ConsoleColor.Red;

                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"Response Status Code: {response.StatusCode}");
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
        public static async Task<int> GetUserID(string username)
        {
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine($"Retrieving User ID for the username: {username}");
            string baseUrl = Global.ApiUrl;
            string apiToken = Global.ApiToken;
            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);

            string url = $"{baseUrl}/users?search={username}";

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var jsonResponse = JObject.Parse(responseBody);

                    // Check if the payload contains any rows
                    var rows = jsonResponse["rows"] as JArray;
                    if (rows != null && rows.Count > 0)
                    {
                        // Access the first element in the rows array
                        var firstRow = rows[0];
                        var id = firstRow["id"];
                        if (id != null)
                        {
                            Console.WriteLine($"ID: {id}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("User not found.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.ToString());
                Console.ResetColor();
            }
            Console.WriteLine("--------------------------------------------------------------");
            return 0;
        }
        public static async Task AssignAssetToUser()
        {
            int user_id = await GetUserID(Environment.UserName);
            string asset_tag = await Global.GetAssetTag();
            asset_tag = asset_tag.TrimStart('0');
            string url = $"{Global.ApiUrl}/hardware/{asset_tag}/checkout";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Global.ApiToken);

            var payload = new
            {
                status = 2,
                checkout_to_type = "user",
                assigned_user = user_id
            };

            string jsonPayload = JsonConvert.SerializeObject(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content);
            }
            else
            {
                Console.WriteLine("Error: " + response.StatusCode);
                string errorResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Error Details: " + errorResponse);
            }
        }
        private static string getMacAddress(int index)
        {
            string mac = getAllNetworkInterfaces()[index].GetPhysicalAddress().ToString();
            var s = mac;
            var list = Enumerable
                .Range(0, s.Length / 2)
                .Select(i => s.Substring(i * 2, 2));
            var res = string.Join("-", list);
            return res;
        }
        private static List<NetworkInterface> getAllNetworkInterfaces()
        {
            List<NetworkInterface> list = new List<NetworkInterface>();
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface nic in interfaces)
            {
                if (nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    list.Add(nic);
                }
            }
            return list;
        }
    }
    //TODO: Method to give user asset automatically if user exists (still leading 0s in the asset_tag)
   
}

