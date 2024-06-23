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
            if (EnvFile.IsFirstRun() == "True")
            {
                AppdataFolder.Create();
                EnvFile.Create();
                AppdataFolder.CreateReadMe();
                EnvFile.Update("FIRST_RUN", "False");
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

    }
}