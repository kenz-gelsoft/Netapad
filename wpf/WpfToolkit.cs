using System.Windows.Input;

namespace Netapad
{
    class WpfToolkit : IToolkit
    {
        public IWindow NewWindow()
        {
            return new WpfWindow();
        }
        public IMenuBar NewMenuBar(MenuDefinition[] aMenus)
        {
            return new WpfMenuBar(aMenus);
        }
        public ITextBox NewTextBox()
        {
            return new WpfTextBox();
        }
        public ICommandBinding NewCommandBinding(ICommand aCommand, ExecutedEventHandler aExecuted, CanExecuteEventHandler aCanExecute)
        {
            return new WpfCommandBinding(aCommand, aExecuted, aCanExecute);
        }
        public IOpenDialog NewOpenDialog()
        {
            return new WpfOpenDialog();
        }
        public ISaveDialog NewSaveDialog()
        {
            return new WpfSaveDialog();
        }
    }
}