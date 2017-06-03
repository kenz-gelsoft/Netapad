using System.Windows.Input;

namespace Netapad
{
    interface IToolkit
    {
        IWindow  NewWindow();
        IMenuBar NewMenuBar(MenuDefinition[] aMenus);
        ITextBox NewTextBox();
        ICommandBinding NewCommandBinding(ICommand aCommand, ExecutedEventHandler aExecuted, CanExecuteEventHandler aCanExecute);
        IOpenDialog NewOpenDialog();
        ISaveDialog NewSaveDialog();
        IAppCommands NewAppCommands();
    }
}