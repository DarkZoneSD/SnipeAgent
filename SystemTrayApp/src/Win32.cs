using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace SystemTrayApp
{
    public class Win32
    {
        public List<String> GetSerialNumber()
        {
            List<String> list = new List<String>();
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher("SELECT Product, SerialNumber FROM Win32_BaseBoard");
            
            ManagementObjectCollection information = searcher.Get();
            foreach(ManagementObject obj in information)
            {
                foreach(PropertyData data in obj.Properties)
                {
                    list.Add(data.Name);
                }
            }
            searcher.Dispose();
            return list;
        }
        public static string GetSystemUUID()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT UUID FROM Win32_ComputerSystemProduct");
                foreach (ManagementObject obj in searcher.Get()) return obj["UUID"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving the System UUID: " + ex.Message);
            }
            return "Could not retrieve System UUID.";
        }
        public static string GetSystemModel()
        {
            try
            {
                ManagementScope scope = new ManagementScope(@"\\.\root\cimv2");
                scope.Connect();

                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_ComputerSystem");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                foreach (ManagementObject mo in searcher.Get())
                {
                    return  mo["Model"].ToString();
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Access denied: " + e.Message);
            }
            catch (ManagementException e)
            {
                Console.WriteLine("WMI query error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
            return "Could not retrieve System Systemmodel.";
        }
        public static string GetManufacturer()
        {
            try
            {
                ManagementScope scope = new ManagementScope(@"\\.\root\cimv2");
                scope.Connect();

                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_ComputerSystem");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                foreach (ManagementObject mo in searcher.Get())
                {
                    return mo["Manufacturer"].ToString();
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Access denied: " + e.Message);
            }
            catch (ManagementException e)
            {
                Console.WriteLine("WMI query error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
            return "Could not retrieve System Systemmodel.";
        }
    }
}
