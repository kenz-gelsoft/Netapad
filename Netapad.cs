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
            app.Run(new EditorWindow());
        }
    }
}
