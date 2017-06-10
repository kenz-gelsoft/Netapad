using AppKit;
using CoreGraphics;
using System.Windows;
using System.Windows.Input;

namespace Netapad
{
    interface IMacControl
    {
        void AddToWindow(MacWindow aWindow);
    }

    class MacWindow : IWindow
    {
        NSWindow window;
        public object Handle {
            get {
                return window;
            }
        }

        public string Title {
            get { return window.Title; }
            set { window.Title = value; }
        }

        public MacWindow()
        {
            var styles = NSWindowStyle.Titled | NSWindowStyle.Resizable | NSWindowStyle.Closable | NSWindowStyle.Miniaturizable;
            window = new NSWindow(new CGRect(0, 0, 640, 480), styles, NSBackingStore.Buffered, false);
            window.SetFrameTopLeftPoint(new CGPoint(0, NSScreen.MainScreen.Frame.Size.Height));
        }

        public void Add(IControl aControl)
        {
            (aControl as IMacControl).AddToWindow(this);
        }

        public void AddCommandBinding(ICommandBinding aBinding)
        {
            // window.CommandBindings.Add(aBinding.Handle as CommandBinding);
        }

        public void Close()
        {
            window.Close();
        }
    }
}