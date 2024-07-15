using DotNetEnv;
using SystemTrayApp.Properties;
using SystemTrayApp.src;
namespace SystemTrayApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if(args.Length > 0)
            {
                if (args[0].Contains("debug"))
                {
                    Console.WriteLine("Debug mode enabled:\n");
                }
                else
                {
                    //Console.SetOut(TextWriter.Null);
                }
            }
            else
            {

                //Console.SetOut(TextWriter.Null);
            }
            string value = @$"{Resources.api_url}
{Resources.api_token}
{Resources.first_run}
{Resources.model_id}
{Resources.status_id}
{Resources.mac_custom_field}
{Resources.uuid_custom_field}";

            AppdataFolder.Create();
            AppdataFolder.CreateReadMe();

            string tempPath = Path.GetTempPath();
            if (!Directory.Exists($@"{tempPath}\SnipeAgent\")) Directory.CreateDirectory($@"{tempPath}\SnipeAgent\");

            EnvFile.Create(value);
            if (DotNetEnv.Env.GetBool("FIRST_RUN"))
            {
                EnvFile.Update("FIRST_RUN", "False");
            }
            try
            {
                SnipeIT.CheckAsset();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}