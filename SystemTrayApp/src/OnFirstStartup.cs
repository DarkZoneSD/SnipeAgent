using DotNetEnv;
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
        public static string uuid_directory_path = $@"{all_users_appdata}\SnipeAgent\Uuid";
        public static void CreateReadMe()
        {
            string value = @"Modify the .Env File to Update the default values of SnipeAgent. These Values can also be set directly inside the application.
Modifying the local values of the application will not have any effect on the values inside the Snipe-IT database, 
for that you have  to actively press ""save"".
------------------------------------------------------------------------------------------------------------------------------
for more information you can ask me on GitHub. https://Github.com/DarkZoneSD/SnipeAgent
";
            if(!File.Exists($@"{snipe_directory_path}\README.txt")) File.WriteAllText($@"{snipe_directory_path}\README.txt", value);
        }
        public static void Create()
        {
            if(!Directory.Exists(snipe_directory_path))
                Directory.CreateDirectory(snipe_directory_path);
            if (!Directory.Exists(uuid_directory_path))
                Directory.CreateDirectory(uuid_directory_path);

        }
    }
    public class EnvFile
    {
        public static string all_users_appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string snipe_directory_path = $@"{all_users_appdata}\SnipeAgent";
        public static void Create(string value) 
        {
            if (!File.Exists($@"{snipe_directory_path}\.Env")) File.WriteAllText($@"{snipe_directory_path}\.Env", value);
        }

        public static void Update(string key, string new_value)
        {
            DotNetEnv.Env.Load();

            string[] linesArray = File.ReadAllLines(Global.EnvFilePath);
            List<string> lines = linesArray.ToList();

            bool variableUpdated = false;

            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].StartsWith($"{key}="))
                {
                    lines[i] = $"{key}={new_value}";
                    variableUpdated = true;
                    break;
                }
            }
            if (!variableUpdated)
            {
                lines.Add($"{key}={new_value}");
            }
            File.WriteAllLines(Global.EnvFilePath, lines);

            Env.Load();
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
