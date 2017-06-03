using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Netapad
{
    class WpfWindow : IWindow
    {
        Window window;
        DockPanel panel;
        public object Handle {
            get {
                return window;
            }
        }

        public string Title {
            get { return window.Title; }
            set { window.Title = value; }
        }

        public WpfWindow()
        {
            window = new Window();
            panel  = new DockPanel();
            window.Content = panel;
        }

        public void Add(IControl aControl)
        {
            panel.Children.Add(aControl.Handle as Control);
        }

        public void AddCommandBinding(ICommandBinding aBinding)
        {
            window.CommandBindings.Add(aBinding.Handle as CommandBinding);
        }

        public void Close()
        {
            window.Close();
        }
    }
}