using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SystemTrayApp.src
{
    public class SnipeIT
    {
        //TODO FIX WRITING TO DB
        public static async Task CreateAsset(string asset_name, string serial_number, int model_number, string mac, string uuid)
        {
            DotNetEnv.Env.Load(".env");
            string baseUrl = DotNetEnv.Env.GetString("API_URL");
            string apiToken = DotNetEnv.Env.GetString("API_TOKEN");
            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);

            if (mac.Contains('-')) mac = mac.Replace('-', ':');

            var asset = new
            {
                //no asset tag necessary for creation
                name = asset_name,
                model_id = model_number,
                serial = serial_number,
                status_id = 2, // Assuming 2 corresponds to 'Ready to Deploy'
                _snipeit_mac_address_1 = mac,
                _snipeit_uuid_2 = uuid
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
        }
        public static async Task CreateDefaultModel()
        {
            DotNetEnv.Env.Load(".env");
            string baseUrl = DotNetEnv.Env.GetString("API_URL");
            int indexOfLastSlash = baseUrl.LastIndexOf("/");
            //TODO FIX Model Creation
            string modelUrl = baseUrl.Substring(0, indexOfLastSlash) + "/model";
            string apiToken = DotNetEnv.Env.GetString("API_TOKEN");
            var client = new HttpClient();
            MessageBox.Show(modelUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);

            var model = new
            {
                name = "Default_Model"
            };
            
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(modelUrl, content);

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
    }
}
