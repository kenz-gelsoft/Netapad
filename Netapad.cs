using System.Windows;

public partial class Netapad : Application
{
    void Netapad_Startup(object sender, StartupEventArgs e)
    {
        NetapadWindow w = new NetapadWindow();
        w.Show();
    }
}
