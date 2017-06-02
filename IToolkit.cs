using System.Windows.Input;

namespace Netapad
{
    interface IToolkit
    {
        IWindow  NewWindow();
        IMenuBar NewMenuBar(MenuDefinition[] aMenus);
        ITextBox NewTextBox();
        ICommandBinding NewCommandBinding(ICommand cmd, ExecutedEventHandler executed, CanExecuteEventHandler canExecute);
        IOpenDialog NewOpenDialog();
        ISaveDialog NewSaveDialog();
    }
}