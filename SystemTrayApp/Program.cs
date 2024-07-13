using DotNetEnv;
using SystemTrayApp.src;
namespace SystemTrayApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            string fileName = "EnvVariables.txt";
            string baseDirectory = GetBaseDirectory("SnipeAgent");
            string value = "";
            if (baseDirectory != null)
            {
                string filePath = Path.Combine(baseDirectory, fileName);
                if (File.Exists(filePath))
                {
                    value = File.ReadAllText(filePath);
                }
                else
                {
                    Console.WriteLine("File not found.");
                }
            } 
            else
            {
                Console.WriteLine("Base directory 'SnipeAgent' not found.");
            }
            //TODO: remove EnvVariables.txt and replace with assembly resources
            AppdataFolder.Create();
            AppdataFolder.CreateReadMe();

            string tempPath = Path.GetTempPath();
            string logFilePath = $@"{tempPath}\SnipeAgent\SnipeAgentLog.txt";
            if (!Directory.Exists($@"{tempPath}\SnipeAgent\")) Directory.CreateDirectory($@"{tempPath}\SnipeAgent\");
            LogWriter logWriter = new LogWriter(logFilePath);
            //Console.SetOut(logWriter);

            EnvFile.Create(value);
            if (DotNetEnv.Env.GetBool("FIRST_RUN"))
            {
                EnvFile.Update("FIRST_RUN", "False");
            }
            try
            {
                SnipeIT.CheckAsset();
               // SnipeIT.AssignAssetToUser();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
        static string GetBaseDirectory(string targetDirectoryName)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory);

            while (directoryInfo != null && directoryInfo.Name != targetDirectoryName)
            {
                directoryInfo = directoryInfo.Parent;
            }

            return directoryInfo?.FullName;
        }

    }
}