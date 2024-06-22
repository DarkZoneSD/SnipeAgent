using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using DotNetEnv;
using SystemTrayApp.src;
namespace SystemTrayApp
{
    public class Global
    {
        private static string host_name = System.Environment.MachineName;
        public static string HostName
        {
            get { return host_name; }
            set { host_name = value; }
        }

        public static string serial_number = RetrieveMethods.GetFirstSerialNumber();
        public static string SerialNumber
        {
            get { return serial_number; }
            set { serial_number = value; }
        }

        private static string api_url = RetrieveMethods.GetApiUrl();
        public static string ApiUrl
        {
            get { return api_url; }
            set { api_url = value; }
        }

        private static string api_token = RetrieveMethods.GetApiToken();
        public static string ApiToken
        {
            get { return api_token; }
            set { api_token = value; }
        }
        private static string env_file_path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\SnipeAgent\.Env";
        public static string EnvFilePath
        {
            get { return env_file_path;}
            set { env_file_path = value; }
        }
        private static string uuid = RetrieveMethods.UuidGlobalVar();
        public static string Uuid
        {
            get { return uuid; }
            set { uuid = value; }
        }
        private static string manufacturer = Win32.GetManufacturer();
        public static string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }
        public static string system_model = Win32.GetSystemModel();
        public static string SystemModel
        {
            get { return system_model; }
            set { system_model = value; }
        }
    }

    public class RetrieveMethods
    {
        public static string UuidGlobalVar()
        {
            return Uuid.Get();
        }
        public static string GetFirstSerialNumber()
        {
            SystemTrayApp.Win32 win32 = new SystemTrayApp.Win32();
            List<string> list = win32.GetSerialNumber();
            return list[0];
        }
        public static string GetApiToken()
        {
            DotNetEnv.Env.Load(".env");
            return DotNetEnv.Env.GetString("API_TOKEN");
        }
        public static string GetApiUrl()
        {
            DotNetEnv.Env.Load(".env");
            return DotNetEnv.Env.GetString("API_URL");
        }
    }
}
