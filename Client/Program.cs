using Client.Session;

namespace Client
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
            ApplicationConfiguration.Initialize();
            // Application.Run(new FrmPrijaviVlasnik());  //ne otvara se direktno vec preko koordinatora koji ce inicijalizovati kontroler i formu
            Koordinator.Instance.OtvoriFrmPrijaviVlasnik();
            if (Koordinator.Instance.UlogovaniVlasnik != null)
            {
                Application.Run(Koordinator.Instance.FrmGlavna);
            }
        }
    }
}