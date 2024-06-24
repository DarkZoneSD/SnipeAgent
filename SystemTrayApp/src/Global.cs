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
        private static string model_id = RetrieveMethods.GetModelID();
        public static string ModelID
        {
            get { return model_id; }
            set { model_id = value; }
        }
        private static string status_id = RetrieveMethods.GetStatusID();
        public static string StatusID
        {
            get { return status_id; }
            set { status_id = value; }
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

        #region AssetTag
        public static string asset_tag;
        public static string AssetTag
        {
            get { return asset_tag; }
            set { asset_tag = value; }
        }
        public async static Task<String> GetAssetTag()
        {
            return await SnipeIT.GetAssetProperties(Global.Uuid, "asset_tag");
        }
        #endregion

        #region AssetName
        private static string asset_name; // Private field to store the asset name

        public static string AssetName
        {
            get { return asset_name; }
            set { asset_name = value; }
        }
        public async static Task<string> GetAssetName()
        {
            return await SnipeIT.GetAssetProperties(Global.Uuid, "name");
        }
        #endregion

        #region AssetCategory
        public static string asset_category;
        public static string AssetCategory
        {
            get { return asset_category; }
            set { asset_category = value; }
        }
        public async static Task<String> GetAssetCategory()
        {
            return await SnipeIT.GetAssetNestedProperties(Global.Uuid, new string[]{ "category", "name"});
        }
        #endregion

        #region AssetSerial
        public static string asset_serial;
        public static string AssetSerial
        {
            get { return asset_serial; }
            set { asset_serial = value; }
        }
        public async static Task<String> GetAssetSerial()
        {
            return await SnipeIT.GetAssetProperties(Global.Uuid, "serial");
        }
        #endregion

        #region AssetModel
        public static string asset_model;
        public static string AssetModel
        {
            get { return asset_model; }
            set { asset_model = value; }
        }
        public async static Task<String> GetAssetModel()
        {
            return await SnipeIT.GetAssetNestedProperties(Global.Uuid, new string[] { "model", "name" });
        }
        #endregion

        #region AssetModelNo
        public static string asset_model_no;
        public static string AssetModelNo
        {
            get { return asset_model_no; }
            set { asset_model_no = value; }
        }
        public async static Task<String> GetAssetModelNo()
        {
            return await SnipeIT.GetAssetProperties(Global.Uuid, "model_number");
        }
        #endregion

        #region AssetMAC
        public static string asset_mac;
        public static string AssetMAC
        {
            get { return asset_mac; }
            set { asset_mac = value; }
        }
        public async static Task<String> GetAssetMAC()
        {
            return await SnipeIT.GetAssetNestedProperties(Global.Uuid, new string[] { "custom_fields", "MAC Address", "value" });
        }
        #endregion

        #region AssetUUID
        public static string asset_uuid;
        public static string AssetUUID
        {
            get { return asset_uuid; }
            set { asset_uuid = value; }
        }

        public async static Task<String> GetAssetUUID()
        {
            return await SnipeIT.GetAssetNestedProperties(Global.Uuid, new string[] { "custom_fields", "UUID", "value" });
        }
        #endregion
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
            DotNetEnv.Env.Load($@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\SnipeAgent\.Env");
            return DotNetEnv.Env.GetString("API_TOKEN");
        }
        public static string GetApiUrl()
        {
            DotNetEnv.Env.Load($@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\SnipeAgent\.Env");
            return DotNetEnv.Env.GetString("API_URL");
        }
        public static string GetModelID()
        {
            DotNetEnv.Env.Load($@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\SnipeAgent\.Env");
            return DotNetEnv.Env.GetString("MODEL_ID");
        }
        public static string GetStatusID()
        {
            DotNetEnv.Env.Load($@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\SnipeAgent\.Env");
            return DotNetEnv.Env.GetString("STATUS_ID");
        }
    }
}
