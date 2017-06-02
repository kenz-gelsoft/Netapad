using System;
using System.Windows;

namespace Netapad
{
    class App : Application
    {
        [STAThread]
        static void Main()
        {
            var app = new App();
            var toolkit = new WpfToolkit();
            var win = new EditorWindow(toolkit);
            app.Run(win.Handle as Window);
        }
    }
}
