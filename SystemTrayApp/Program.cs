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

            AppdataFolder.Create();
            AppdataFolder.CreateReadMe();
            EnvFile.Create();
            if (DotNetEnv.Env.GetBool("FIRST_RUN"))
            {
                EnvFile.Update("FIRST_RUN", "False");
            }
            SnipeIT.CheckAsset();
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

    }
}