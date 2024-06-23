﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DotNetEnv;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SystemTrayApp.src
{
    public class SnipeIT
    {
        //TODO FIX WRITING TO DB
        public static async Task CreateAsset(string asset_name, string serial_number, string mac, string uuid)
        {
            DotNetEnv.Env.Load(".env");

            string baseUrl = Global.ApiUrl;
            string apiToken = Global.ApiToken;
            string modelId = Global.ModelID;
            string statusId = Global.StatusID;
            // Debugging statements
            try
            {
                Console.WriteLine($"API_URL: {baseUrl}\nAPI_TOKEN: {apiToken}\nMODEL: {modelId}");

                var client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);

                if (mac.Contains('-')) mac = mac.Replace('-', ':');

                var asset = new
                {
                    name = asset_name,
                    model_id = modelId, // Use the modelId read from the .env file
                    serial = serial_number,
                    status_id = statusId, // Assuming 2 corresponds to 'Ready to Deploy'
                    _snipeit_mac_address_1 = mac,
                    _snipeit_uuid_2 = uuid
                };

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(asset);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(baseUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    //if (responseBody.Contains("_snipeit_uuid_2"))
                    //{
                    //    MessageBox.Show(@$"The UUID already exists in the Database. Delete the asset from the database or update the UUID by resetting it in" +
                    //        " the settings or deleting the Appdata\\SnipeAgent folder to regenerate the files.");
                    //}
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
                        Console.WriteLine("Asset retrieved successfully. Response: " + responseBody);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Asset not found.");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Error: " + response.StatusCode);
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
            Console.WriteLine($"Retrieving data for property: {key} of the asset with UUID:{uuid}");
            string baseUrl = Global.ApiUrl;
            string apiToken = Global.ApiToken;
            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);

            string url = $"{baseUrl}?search={uuid}";

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

            return null;
        }
        public static async void CheckAsset()
        {
            bool assetExists = await Task.Run(() => SnipeIT.GetAssetByUuid(Global.Uuid));
            if (!assetExists) SnipeIT.CreateAsset(Global.HostName, Global.SerialNumber, "", Global.Uuid);
        }
        //TODO: be able to retrieve nested JSON objects
        public static async Task<string> GetAssetNestedProperties(string uuid, string key)
        {
            Console.WriteLine($"Retrieving data for property: {key} of the asset with UUID:{uuid}");
            string baseUrl = Global.ApiUrl;
            string apiToken = Global.ApiToken;
            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);

            string url = $"{baseUrl}?search={uuid}";

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

            return null;
        }
    }
}

