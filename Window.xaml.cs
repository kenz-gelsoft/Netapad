using System.Windows;
using System.Windows.Controls;

public partial class NetapadWindow : Window
{
    public NetapadWindow()
    {
        this.Title = "ネタ帳";

        Button button = new Button();
        button.Content = "Click Me!";
        button.Width = 100;
        button.Height = 50;
        button.Click += NetapadWindow_Click;

        this.Content = button;
    }

    void NetapadWindow_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("クリックされました！");
    }
}
