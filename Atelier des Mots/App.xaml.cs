using System;
using System.Windows;

namespace Atelier_des_Mots
{
    public partial class App : Application
    {
        // Override OnStartup to handle any initialization logic before the app starts
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // Add any necessary startup logic here, such as logging or settings initialization
        }

        // Override OnExit to perform cleanup tasks when the app is shutting down
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            // Perform any necessary cleanup, such as saving settings or releasing resources
        }
    }
}
