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
            var win = new EditorWindow();
            app.Run(win.Native);
        }
    }
}
