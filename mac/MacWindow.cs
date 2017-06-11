using AppKit;
using CoreGraphics;
using System.Collections.Generic;
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

        Dictionary<ICommand, MacCommandBinding> mBindings = new Dictionary<ICommand, MacCommandBinding>();
        public void AddCommandBinding(ICommandBinding aBinding)
        {
            var macBinding = aBinding as MacCommandBinding;
            mBindings[macBinding.Command] = macBinding;
        }
        public ICommand BindingOrCommand(ICommand aCommand)
        {
            MacCommandBinding found = null;
            return mBindings.TryGetValue(aCommand, out found)
                ? found
                : aCommand;
        }

        public void Close()
        {
            window.Close();
        }
    }
}