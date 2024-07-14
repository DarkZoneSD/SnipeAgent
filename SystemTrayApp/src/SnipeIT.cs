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
using System.Net.NetworkInformation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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

                var asset = new Dictionary<string, object>
                {
                    ["name"] = asset_name,
                    ["model_id"] = modelId,
                    ["serial"] = serial_number,
                    ["status_id"] = statusId,
                    ["category"] = 2 // Assuming 'category' is a fixed property, adjust as necessary
                };

                asset[macCustomField] = mac;
                asset[uuidCustomField] = uuid;

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(asset);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync($"{baseUrl}/hardware", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    Console.WriteLine("Asset created successfully. Response: " + responseBody);
                    AssignAssetToUser(false); //false because when creating the asset the asset is not checked out currently, if it were it would be true
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
                        if (row != null)
                        {
                            if (row.model_number == modelNumber.Trim())
                            {
                                Console.WriteLine($"Model from JSON: {row.model_number?.ToString()}\n Model from local machine: {modelNumber} \n returning true");
                                return true;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Model from JSON: {row.model_number?.ToString()}\n Model from local machine: {modelNumber} \n Row is null.");
                        }
                    }
                }
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
                        if (row != null)
                        {
                            Console.WriteLine($"Model from JSON: {row.model_number?.ToString()}\n Model from local machine: {modelNumber}"); 

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
            string resp = "";
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
                    if (rows != null && rows.HasValues)
                    {
                        foreach (var row in rows)
                        {
                            var value = row[key]?.ToString();
                            if (value != null)
                            {
                                Console.WriteLine($"Value: {value}");
                                return value;
                            }
                        }
                        resp = "Asset retrieved successfully.\n";
                    }
                    else
                    {
                        resp = "Asset not found.";
                    }
                }
                else
                {
                    resp = "Error: " + response.StatusCode;
                }
            }catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.ToString());
                Console.ResetColor();
            }

            string codeResponse = $"Response: {resp}";
            string consoleOutput = @$"--------------------------------------------------------------
Retrieving data for property: {key} of the asset with UUID:{uuid}
{codeResponse}
--------------------------------------------------------------";
            Console.ForegroundColor= ConsoleColor.Blue;
            Console.WriteLine(consoleOutput);
            Console.ResetColor();
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
        public static async Task<string> GetAssetNestedProperties(string uuid, string[] key)
        {
            Console.WriteLine("--------------------------------------------------------------\n" +
            "\u001b[0mRetrieving data for property: " +
            string.Join(" ", key.Select(k => "\u001b[34m" + k + "\u001b[0m")) +
            "\u001b[0m of the asset with UUID: \u001b[34m" + uuid + "\u001b[0m");


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
                                        return row[key[0]][key[1]][key[2]]?.ToString();
                                        break;
                                    default:
                                        return row[key[0]][key[1]]?.ToString();
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
            string baseUrl = Global.ApiUrl;
            string apiToken = Global.ApiToken; 

            try
            {
                var client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);

                string status_string = "";
                string url = $"{baseUrl}/hardware/{id}";
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(propertiesToUpdate);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    status_string = "Hardware asset property updated successfully.";
                }
                else
                {
                    status_string = $"Error updating hardware asset. Status Code: {response.StatusCode}";
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Log response headers for additional debugging information
                    foreach (var header in response.Headers)
                    {
                        Console.WriteLine($"{header.Key}: {string.Join(", ", header.Value)}");
                    }
                }
                Console.WriteLine("--------------------------------------------------------------\n" +
                  "Attempting to update hardware asset with ID:" +
                  "\u001b[34m" + id + "\u001b[0m\n" +
                  "API_URL: \u001b[34m" + url + "\u001b[0m\n\n" +
                  "Request Body:\u001b[43;30m" + json + "\u001b[0m\n\n" +
                  "Status: " + status_string + "\n" +
                  "--------------------------------------------------------------");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(@$"--------------------------------------------------------------
Request failed: {ex.Message}
--------------------------------------------------------------");
            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine(@$"--------------------------------------------------------------
Request timed out or was canceled: {ex.Message}
--------------------------------------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine(@$"--------------------------------------------------------------
An unexpected error occurred: {ex.Message}
--------------------------------------------------------------");
            }

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
                    string string_id = "";

                    var rows = jsonResponse["rows"] as JArray;
                    if (rows != null && rows.Count > 0)
                    {
                        var firstRow = rows[0];
                        var id = firstRow["id"];
                        if (id != null)
                        {
                            Console.WriteLine($"ID: {id}");
                            string_id = id.ToString();
                            return int.Parse(string_id);
                        }
                        else
                        {
                            MessageBox.Show("No user with the current Username: " + Environment.UserName + " in the database!", "No user found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return 0;
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

        public static async Task AssignAssetToUser(bool asset_is_already_checked_out, string username = null)
        {
            if(username == null)
            {
                username = Environment.UserName;
            }
            Console.WriteLine("ASSIGNING TO USER: " + username);
            int user_id = await GetUserID(username);
            string asset_tag = await Global.GetAssetTag();
            asset_tag = asset_tag.TrimStart('0');
            string url = $"{Global.ApiUrl}/hardware/{asset_tag}/checkout";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Global.ApiToken);

            if (asset_is_already_checked_out)
            {
                await CheckInAsset(asset_tag);
            }
            
            var payload = new
            {
                status = 2,
                checkout_to_type = "user",
                assigned_user = user_id
            };

            string jsonPayload = JsonConvert.SerializeObject(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            try
            {

                HttpResponseMessage response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Assigning asset to user: "+ username + "\n" + response.StatusCode);
                }
                else
                {
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Assigning asset to user: "+ username + "\n" + "Error: " + response.StatusCode + "\n" + "Error Details: " + errorResponse);
                }
            }catch (Exception ex)
            {
                Console.WriteLine("Error assigning asset to user: " + username + "\n" + ex.ToString());
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
        private static async Task CheckInAsset(string asset_tag)
        {
            asset_tag = asset_tag.TrimStart('0');
            string url = $"{Global.ApiUrl}/hardware/{asset_tag}/checkin";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Global.ApiToken);

            var payload = new
            {
                status = asset_tag,
                status_id = 2
            };

            string jsonPayload = JsonConvert.SerializeObject(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            try
            {

                HttpResponseMessage response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Checking in asset: " + asset_tag + "\n" + response.StatusCode);
                }
                else
                {
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Checking in asset: " + asset_tag + "\n" + "Error: " + response.StatusCode + "\n" + "Error Details: " + errorResponse);
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
   
}

