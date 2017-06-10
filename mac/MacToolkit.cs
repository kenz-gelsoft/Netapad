using AppKit;
using System.Windows.Input;

namespace Netapad
{
    class MacToolkit : NSApplicationDelegate, IToolkit
    {
        public MacToolkit()
        {
            NSApplication.SharedApplication.Delegate = this;
        }

        public override bool ApplicationShouldTerminateAfterLastWindowClosed(NSApplication sender)
        {
            return true;
        }

        public IWindow NewWindow()
        {
            return new MacWindow();
        }
        public IMenuBar NewMenuBar(MenuDefinition[] aMenus)
        {
            return new MacMenuBar(aMenus);
        }
        public ITextBox NewTextBox()
        {
            return new MacTextBox();
        }
        public ICommandBinding NewCommandBinding(ICommand aCommand, ExecutedEventHandler aExecuted, CanExecuteEventHandler aCanExecute)
        {
            return new MacCommandBinding(aCommand, aExecuted, aCanExecute);
        }
        public IOpenDialog NewOpenDialog()
        {
            return new MacOpenDialog();
        }
        public ISaveDialog NewSaveDialog()
        {
            return new MacSaveDialog();
        }
        public IAppCommands NewAppCommands()
        {
            return new MacAppCommands();
        }
    }
}