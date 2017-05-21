using System.Windows;
using System.Windows.Controls;

public partial class NetapadWindow : Window
{
    public NetapadWindow()
    {
        this.Title = "ネタ帳";

        DockPanel panel = new DockPanel();

        Menu menuBar = BuildMenuBar();
        DockPanel.SetDock(menuBar, Dock.Top);
        panel.Children.Add(menuBar);

        TextBox textBox = new TextBox();
        textBox.AcceptsReturn = true;
        panel.Children.Add(textBox);

        this.Content = panel;
    }

    Menu BuildMenuBar()
    {
        Menu menuBar = new Menu();

        MenuItem fileMenu = new MenuItem();
        fileMenu.Header = "ファイル(_F)";

        MenuItem fileExit = new MenuItem();
        fileExit.Header = "終了(_X)";
        fileExit.Click += NetapadWindow_FileExitClick;
        fileMenu.Items.Add(fileExit);

        menuBar.Items.Add(fileMenu);

        return menuBar;
    }

    void NetapadWindow_FileExitClick(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
