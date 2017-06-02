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
        public ICommandBinding NewCommandBinding(ICommand cmd, ExecutedEventHandler executed, CanExecuteEventHandler canExecute)
        {
            return new WpfCommandBinding(cmd, executed, canExecute);
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