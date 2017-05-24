using System;
using System.Windows;

public class Netapad : Application
{
    [STAThread]
    static void Main()
    {
        var app = new Netapad();
        app.Run(new NetapadWindow());
    }
}
