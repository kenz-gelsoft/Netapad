using System;
using System.Windows;

public class Netapad : Application
{
    [STAThread]
    static void Main()
    {
        Netapad app = new Netapad();
        app.Run(new NetapadWindow());
    }
}
