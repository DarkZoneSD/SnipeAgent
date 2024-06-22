using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemTrayApp.src
{
    public class AppdataFolder
    {
        public static string all_users_appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string snipe_directory_path = $@"{all_users_appdata}\SnipeAgent";
        public static void CreateReadMe()
        {
            string value = @"Modify the .Env File to Update the default values of SnipeAgent. These Values can also be set directly inside the application.
Modifying the local values of the application will not have any effect on the values inside the Snipe-IT database, 
for that you have  to actively press ""save"".
------------------------------------------------------------------------------------------------------------------------------
for more information you can ask me on GitHub. https://Github.com/DarkZoneSD/SnipeAgent
";
            File.WriteAllText($@"{snipe_directory_path}\README.txt", value);
        }
    }
    public class EnvFile
    {
        public static string all_users_appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string snipe_directory_path = $@"{all_users_appdata}\SnipeAgent";
        public static void Create() 
        {
            string value = @"
API_URL=http://localhost:8000/api/v1/hardware
API_TOKEN=eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiIxIiwianRpIjoiZWIzZjNkODJhNGNjZmU0YWRiMjg1ZmQzZjYyMDZkNjk0Y2EzNzk0NWE3MGIyNjIzZGFkMTY4NTRkZDBiMTBlZjVlMTZmZmU4YTllMGNjZDkiLCJpYXQiOjE3MTczNDQ4MzYuMDIyMjU2LCJuYmYiOjE3MTczNDQ4MzYuMDIyMjU5LCJleHAiOjIzNDg0OTY4MzYuMDE2NjE1LCJzdWIiOiIxIiwic2NvcGVzIjpbXX0.RV4daNQpfdqAsbTMrXn6erzltSd7nCy7zH1mxZZ9ObEf8ZoN9cXnJ28Ldric28lZRHtPYzKXvcVpcjOFw2TdJgkNQYqmYz4cXUiosQov707IBvpJowSwbLlHC_COHkVdq0Lt1FlwcM8rpv_wG5LX6jkteMJABqKbh2q71U-OtS3g2vvPnNagCO_En-PqcXG9BjiJgs_vozXhVqOV-uaar0mdlbQdyo9E0XbI1StWTejpoPUf0sC6OO-fwRWtX7RDtsTSNOHYwTsluCKK2x7YEgni-DDsmyo-zOAOSmLn0SeRJMEcEP7m0wEVvieTRCY3tGX-afXoRf7gigMjh8hAbgTFWHf0jG26Kdl7tOHW2ei8sGwhvS5T1y_CHZeAKwQ84zOkDqdRzrsaWqfZGT291F4F6jHyvPpFLzEXH9tcG2TqeKGSP1d81WbvaEb1Rt9D-5g1clTl6UFJJhz5Zf8fdCu5FnsvBwvvrfgO_BpBE0mrDS9fNKQEhyXPO7IDC_1IPvVzZa2JedKghoWoQ6lKZ01LoVxT6iUMEKMw8DS8_Fh9rkSO0eTONq5GG-Q44hXwR5JM5wERBMELViDgWZHtgq4-_TMAatlrESdYAV43IdBubStZrmHdasdbM6IjOPdzcgD45pTEF3NgkE9Lt2OZVdroVTlOGkotk2m3IIpFqtU
FIRST_RUN=False
DEFAULT_COMPANY=
DEFAULT_MAC=";
            File.WriteAllText($@"{snipe_directory_path}\.Env", value);
        }
    }
    public class Uuid
    {
        public static string all_users_appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string snipe_directory_path = $@"{all_users_appdata}\SnipeAgent";
        public static string uuid_directory_path = $@"{all_users_appdata}\SnipeAgent\Uuid";
        public static string file_path = $@"{uuid_directory_path}\value.ini";

        public static string Create()
        {
            if(!Directory.Exists(snipe_directory_path)) Directory.CreateDirectory(snipe_directory_path);
            if(!Directory.Exists(uuid_directory_path)) Directory.CreateDirectory(uuid_directory_path);
            string guid = Guid.NewGuid().ToString();
            File.WriteAllText(file_path, guid);
            return guid;
        }

        public static string Update()
        {
            if (File.Exists(file_path)) File.Delete(file_path);
            string guid = Guid.NewGuid().ToString();
            File.WriteAllText(file_path, guid);
            return guid;
        }
        public static void Delete()
        {
            if(File.Exists(file_path)) File.Delete(file_path);
        }
        public static string Get()
        {
            if (File.Exists(file_path))
            {
                string guid = File.ReadAllLines(file_path)[0];
                return guid;
            }
            else
            {
                return(Create());
            }
        }
    }
}
